using System.Web;

namespace InstagramCSharpScraper
{
    public static class Endpoints
    {
        public const string BaseUrl = "https://www.instagram.com";
        public const string LoginUrl = "https://www.instagram.com/accounts/login/ajax/";
        private const string AccountPage = "https://www.instagram.com/{0}";
        private const string AccountMedias = "https://www.instagram.com/graphql/query/?query_hash=42323d64886122307be10013ad2dcc44&variables={0}";


        public static string GetAccountPageLink(string username)
        {
            return string.Format(AccountPage, HttpUtility.UrlEncode(username));
        }

        public static string GetAccountMediasJsonLink(string variables)
        {
            return string.Format(AccountMedias, variables);
        }
    }
}