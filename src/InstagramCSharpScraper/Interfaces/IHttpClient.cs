using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstagramCSharpScraper.Interfaces
{
    public interface IHttpClient
    {
        Task<string> GetStringAsync(string requestUri);
        Task<ResponseResult> PostAsync(string requestUri, string parameters, IEnumerable<KeyValuePair<string, string>>? headers = null);
        Task<ResponseResult> GetAsync(string requestUri);
    }
}