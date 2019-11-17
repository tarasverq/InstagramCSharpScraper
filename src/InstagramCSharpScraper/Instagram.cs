using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using InstagramCSharpScraper.Exceptions;
using InstagramCSharpScraper.Interfaces;
using InstagramCSharpScraper.Models;
using InstagramCSharpScraper.Models.Mapping;
using InstagramCSharpScraper.Models.Raw;
using Newtonsoft.Json;

namespace InstagramCSharpScraper
{
    public class Instagram
    {
        public string UserAgent { get; set; }
            = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_13_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.139 Safari/537.36";
        
        public bool IsLoggedIn { get; private set; }

        private readonly string _username;
        private readonly string _password;
        private readonly IHttpClient _httpClient;
        private string? _csrfToken;
        private readonly IModelMapper _modelMapper;

        public Instagram(string username, string password, IHttpClient httpClient)
        {
            _username = username;
            _password = password;
            _httpClient = httpClient;
         
            _modelMapper = new ModelMapper();
        }
        
        public async Task Login()
        {
            string response = await _httpClient.GetStringAsync(Endpoints.BaseUrl);

            _csrfToken = Regex.Match(response, "csrf_token\":\"(.*?)\"").Groups[1].Value;

            var headers = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("referer", Endpoints.BaseUrl + "/"),
                new KeyValuePair<string, string>("X-CSRFToken", _csrfToken),
                new KeyValuePair<string, string>("user-agent", UserAgent),
            };

            ResponseResult resp = await _httpClient.PostAsync(Endpoints.LoginUrl, $"username={_username}&password={_password}", headers);

            switch (resp.Code)
            {
                case 200:
                    AuthModel authModel = JsonConvert.DeserializeObject<AuthModel>(resp.ResponseBody);
                    if (authModel.authenticated)
                        IsLoggedIn = true;
                    break;
                case 400:
                    //TODO challenge
                    throw new InstagramException();   
                default:
                    //TODO challenge
                    throw new InstagramException();
            }
        }

        public async Task<User> GetAccount(string username)
        {
            string url = Endpoints.GetAccountPageLink(username);
            ResponseResult response = await _httpClient.GetAsync(url);
            CheckStatusCode(response);

            UserModel.ResponseData? deserialized = ExtractSharedDataFromBody(response.ResponseBody);
            UserModel.User? user = deserialized?.EntryData?.ProfilePage?.FirstOrDefault()?.Graphql.User;
            if(user == null)
                throw new InstagramException("Unable to find 'user' model on page");
            
            User mapped = _modelMapper.Map<User>(user);
            return mapped;
        }

        private static void CheckStatusCode(ResponseResult response)
        {
            if (response.Code == 404)
                throw new InstagramNotFoundException("Account with given username does not exist.");
            if (response.Code != 200)
                throw new InstagramException($"Response code is {response.Code}. Body: {response.ResponseBody} Something went wrong. Please report issue.'");
        }

        public async Task<ICollection<Media>> GetMediasByUserId(long id, int count = 12)
        {
            List<Media> result = new List<Media>(count);
            int index = 0;
            bool isMoreAvailable = true;
            string maxId = String.Empty;
            while (index < count && isMoreAvailable)
            {
                var variables = new {id = id.ToString(), first = count.ToString(), after = maxId,};
                string parameters = JsonConvert.SerializeObject(variables);
                string url = Endpoints.GetAccountMediasJsonLink(parameters);

                ResponseResult response = await _httpClient.GetAsync(url);
                CheckStatusCode(response);

                MediaModel.ResponseData model = JsonConvert.DeserializeObject<MediaModel.ResponseData>(response.ResponseBody);
                ICollection<Media> mapped = _modelMapper.Map<ICollection<Media>>(model.Data.User.TimelineMedia.Edges.Select(x=> x.Media).ToList());
                index += mapped.Count;
                result.AddRange(mapped);

                maxId = model.Data.User.TimelineMedia.PageInfo.EndCursor;
                isMoreAvailable = model.Data.User.TimelineMedia.PageInfo.HasNextPage;
            }

            return result;
        }

        private static UserModel.ResponseData? ExtractSharedDataFromBody(string body)
        {
            Regex sharedDataRegex = new Regex(@"_sharedData \= (.*?)\;\<\/script\>");
            Match match = sharedDataRegex.Match(body);
            if (!match.Success)
                return null;

            UserModel.ResponseData deserialized = JsonConvert.DeserializeObject<UserModel.ResponseData>(match.Groups[1].Value);
            return deserialized;
        }
    }
}