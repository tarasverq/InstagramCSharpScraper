namespace InstagramCSharpScraper.Models.Raw
{
    class AuthModel
    {
        public bool authenticated { get; set; }
        public bool user { get; set; }
        public string? userId { get; set; }
        public bool oneTapPrompt { get; set; }
        public string? status { get; set; }
    }
}