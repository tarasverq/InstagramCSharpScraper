#nullable disable
using System;
using System.Collections.Generic;

namespace InstagramCSharpScraper.Models
{
    public class Media
    {
        public string Id { get; set; }
        public string Typename { get; set; }
        public string Caption { get; set; }
        public string Shortcode { get; set; }
        public long CommentsCount { get; set; }
        public bool CommentsDisabled { get; set; }
        public long TakenAtTimestamp { get; set; }
        public Dimensions Dimensions { get; set; }
        public string DisplayUrl { get; set; }
        public long LikesCount { get; set; }
        public Location Location { get; set; }
        public object GatingInfo { get; set; }
        public string MediaPreview { get; set; }
        public Owner Owner { get; set; }
        public string ThumbnailSrc { get; set; }
        public List<Thumbnail> Thumbnails { get; set; }
        public bool IsVideo { get; set; }
        public long? VideoViewCount { get; set; }
        
        public DateTimeOffset TakenAtDateTimeOffset => 
            (new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.FromHours(0)))
            .AddSeconds(TakenAtTimestamp);
    }
    
    public class Dimensions
    {
        public long Height { get; set; }
        public long Width { get; set; }
    }
    
    public class Thumbnail
    {
        public string Src { get; set; }
        public long ConfigWidth { get; set; }
        public long ConfigHeight { get; set; }
    }
    
    public class Location
    {
        public long Id { get; set; }
        public bool HasPublicPage { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
    
    public class Owner
    {
        public long Id { get; set; }
        public string Username { get; set; }
    }
}