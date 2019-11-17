using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using InstagramCSharpScraper.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace InstagramCSharpScraper
{
    public class DefaultHttpClient : IHttpClient, IDisposable
    {
        private readonly HttpClientHandler _handler;
        private readonly HttpClient _client;
        private readonly CookieContainer _cookieContainer;

        public DefaultHttpClient()
        {
            _cookieContainer = new CookieContainer();
            _handler = new HttpClientHandler() {CookieContainer = _cookieContainer};
            _client = new HttpClient(_handler);
        }
        
        public string? GetCookieByName(string requestUri, string name)
        {
            CookieCollection cookies = _cookieContainer.GetCookies(new Uri(requestUri));
            Cookie? cookie = (cookies as ICollection<Cookie>).FirstOrDefault(x => x.Name == name);

            string? value = cookie?.Value;
            return value;
        }

        public Task<string> GetStringAsync(string requestUri)
        {
            return _client.GetStringAsync(requestUri);
        }
        
        public async Task<ResponseResult> GetAsync(string requestUri)
        {
            HttpResponseMessage response = await _client.GetAsync(requestUri);
            ResponseResult result =  await GetResult(response);
            return result;
        }


        public async Task<ResponseResult> PostAsync(string requestUri, string parameters, IEnumerable<KeyValuePair<string, string>>? headers = null)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, requestUri);
            if(headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    message.Headers.Add(header.Key, header.Value);
                }
            }
            message.Content = new StringContent(parameters, Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpResponseMessage response = await  _client.SendAsync(message).ConfigureAwait(false);  
            
            ResponseResult result =  await GetResult(response);
            return result;
        }

        private async Task<ResponseResult> GetResult(HttpResponseMessage response)
        {
            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            int code = (int)response.StatusCode;

            return new ResponseResult() {ResponseBody = responseBody, Code = code};
        }

        public void Dispose()
        {
            _handler?.Dispose();
            _client?.Dispose();
        }
    }
}