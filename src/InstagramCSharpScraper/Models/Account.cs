#nullable disable

namespace InstagramCSharpScraper.Models
{
    /// <summary>
    /// User object
    /// </summary>
    public class User
    {
        public string Biography { get; set; }
        public bool BlockedByViewer { get; set; }
        public bool CountryBlock { get; set; }
        public string ExternalUrl { get; set; }
        public string ExternalUrlLinkshimmed { get; set; }
        public long FollowedBy { get; set; }
        public bool FollowedByViewer { get; set; }
        public long Follow { get; set; }
        public bool FollowsViewer { get; set; }
        public string FullName { get; set; }
        public bool HasChannel { get; set; }
        public bool HasBlockedViewer { get; set; }
        public long HighlightReelCount { get; set; }
        public bool HasRequestedViewer { get; set; }
        public long Id { get; set; }
        public bool IsBusinessAccount { get; set; }
        public bool IsJoinedRecently { get; set; }
        public string BusinessCategoryName { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsVerified { get; set; }
        public string ProfilePicUrl { get; set; }
        public string ProfilePicUrlHd { get; set; }
        public bool RequestedByViewer { get; set; }
        public string Username { get; set; }

        public object ConnectedFbPage { get; set; }
//            public EdgeMutualFollowedBy MutualFollowedBy { get; set; }
//            public EdgeFelixVideoTimelineClass VideoTimeline { get; set; }
//            public EdgeFelixVideoTimelineClass TimelineMedia { get; set; }
//            public EdgeFelixVideoTimelineClass SavedMedia { get; set; }
//            public EdgeFelixVideoTimelineClass MediaCollections { get; set; }
    }
}