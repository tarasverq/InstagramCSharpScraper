#nullable disable
using Newtonsoft.Json;

namespace InstagramCSharpScraper.Models.Raw
{
    class MediaModel
    {
        public class ResponseData
        {
            [JsonProperty("data")]
            public UserModel.Graphql Data { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }
        }
    }
}