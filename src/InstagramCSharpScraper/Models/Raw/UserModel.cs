#nullable disable

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace InstagramCSharpScraper.Models.Raw
{
    class UserModel
    {
        public class ResponseData
        {
            [JsonProperty("entry_data")]
            public EntryData EntryData { get; set; }
        }

        public class EntryData
        {
            [JsonProperty("ProfilePage")]
            public List<ProfilePage> ProfilePage { get; set; }
        }

        public class ProfilePage
        {
            [JsonProperty("logging_page_id")]
            public string LoggingPageId { get; set; }

            [JsonProperty("show_suggested_profiles")]
            public bool ShowSuggestedProfiles { get; set; }

            [JsonProperty("show_follow_dialog")]
            public bool ShowFollowDialog { get; set; }

            [JsonProperty("graphql")]
            public Graphql Graphql { get; set; }

            [JsonProperty("toast_content_on_load")]
            public object ToastContentOnLoad { get; set; }
        }

        public class Graphql
        {
            [JsonProperty("user")]
            public User User { get; set; }
        }

        public class User
        {
            [JsonProperty("biography")]
            public string Biography { get; set; }

            [JsonProperty("blocked_by_viewer")]
            public bool BlockedByViewer { get; set; }

            [JsonProperty("country_block")]
            public bool CountryBlock { get; set; }

            [JsonProperty("external_url")]
            public string ExternalUrl { get; set; }

            [JsonProperty("external_url_linkshimmed")]
            public string ExternalUrlLinkshimmed { get; set; }

            [JsonProperty("edge_followed_by")]
            public EdgeFollowClass FollowedBy { get; set; }

            [JsonProperty("followed_by_viewer")]
            public bool FollowedByViewer { get; set; }

            [JsonProperty("edge_follow")]
            public EdgeFollowClass Follow { get; set; }

            [JsonProperty("follows_viewer")]
            public bool FollowsViewer { get; set; }

            [JsonProperty("full_name")]
            public string FullName { get; set; }

            [JsonProperty("has_channel")]
            public bool HasChannel { get; set; }

            [JsonProperty("has_blocked_viewer")]
            public bool HasBlockedViewer { get; set; }

            [JsonProperty("highlight_reel_count")]
            public long HighlightReelCount { get; set; }

            [JsonProperty("has_requested_viewer")]
            public bool HasRequestedViewer { get; set; }

            [JsonProperty("id")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Id { get; set; }

            [JsonProperty("is_business_account")]
            public bool IsBusinessAccount { get; set; }

            [JsonProperty("is_joined_recently")]
            public bool IsJoinedRecently { get; set; }

            [JsonProperty("business_category_name")]
            public string BusinessCategoryName { get; set; }

            [JsonProperty("is_private")]
            public bool IsPrivate { get; set; }

            [JsonProperty("is_verified")]
            public bool IsVerified { get; set; }

            [JsonProperty("edge_mutual_followed_by")]
            public EdgeMutualFollowedBy MutualFollowedBy { get; set; }

            [JsonProperty("profile_pic_url")]
            public string ProfilePicUrl { get; set; }

            [JsonProperty("profile_pic_url_hd")]
            public string ProfilePicUrlHd { get; set; }

            [JsonProperty("requested_by_viewer")]
            public bool RequestedByViewer { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonProperty("connected_fb_page")]
            public object ConnectedFbPage { get; set; }

            [JsonProperty("edge_felix_video_timeline")]
            public EdgeFelixVideoTimelineClass VideoTimeline { get; set; }

            [JsonProperty("edge_owner_to_timeline_media")]
            public EdgeFelixVideoTimelineClass TimelineMedia { get; set; }

            [JsonProperty("edge_saved_media")]
            public EdgeFelixVideoTimelineClass SavedMedia { get; set; }

            [JsonProperty("edge_media_collections")]
            public EdgeFelixVideoTimelineClass MediaCollections { get; set; }
        }

        public class EdgeMutualFollowedBy
        {
            [JsonProperty("count")]
            public long Count { get; set; }

            [JsonProperty("edges")]
            public List<object> Edges { get; set; }
        }

        public class EdgeFelixVideoTimelineClass
        {
            [JsonProperty("count")]
            public long Count { get; set; }

            [JsonProperty("page_info")]
            public PageInfo PageInfo { get; set; }

            [JsonProperty("edges")]
            public List<EdgeFelixVideoTimelineEdge> Edges { get; set; }
        }

        public class PageInfo
        {
            [JsonProperty("has_next_page")]
            public bool HasNextPage { get; set; }

            [JsonProperty("end_cursor")]
            public string EndCursor { get; set; }
        }

        public class EdgeFelixVideoTimelineEdge
        {
            [JsonProperty("node")]
            public Media Media { get; set; }
        }

        public class Media
        {
            [JsonProperty("__typename")]
            public string Typename { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("edge_media_to_caption")]
            public EdgeMediaToCaption Caption { get; set; }

            [JsonProperty("shortcode")]
            public string Shortcode { get; set; }

            [JsonProperty("edge_media_to_comment")]
            public EdgeFollowClass Comment { get; set; }

            [JsonProperty("comments_disabled")]
            public bool CommentsDisabled { get; set; }

            [JsonProperty("taken_at_timestamp")]
            public long TakenAtTimestamp { get; set; }

            [JsonProperty("dimensions")]
            public Dimensions Dimensions { get; set; }

            [JsonProperty("display_url")]
            public string DisplayUrl { get; set; }

            [JsonProperty("edge_liked_by")]
            public EdgeFollowClass LikedBy { get; set; }

            [JsonProperty("edge_media_preview_like")]
            public EdgeFollowClass EdgeMediaPreviewLike { get; set; }

            [JsonProperty("location")]
            public Location Location { get; set; }

            [JsonProperty("gating_info")]
            public object GatingInfo { get; set; }

            [JsonProperty("fact_check_overall_rating")]
            public object FactCheckOverallRating { get; set; }

            [JsonProperty("fact_check_information")]
            public object FactCheckInformation { get; set; }

            [JsonProperty("media_preview")]
            public string MediaPreview { get; set; }

            [JsonProperty("owner")]
            public Owner Owner { get; set; }

            [JsonProperty("thumbnail_src")]
            public string ThumbnailSrc { get; set; }

            [JsonProperty("thumbnail_resources")]
            public List<ThumbnailResource> ThumbnailResources { get; set; }

            [JsonProperty("is_video")]
            public bool IsVideo { get; set; }

            [JsonProperty("felix_profile_grid_crop")]
            public object FelixProfileGridCrop { get; set; }

            [JsonProperty("encoding_status")]
            public object EncodingStatus { get; set; }

            [JsonProperty("is_published", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsPublished { get; set; }

            [JsonProperty("product_type", NullValueHandling = NullValueHandling.Ignore)]
            public string ProductType { get; set; }

            [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
            public string Title { get; set; }

            [JsonProperty("video_duration", NullValueHandling = NullValueHandling.Ignore)]
            public double? VideoDuration { get; set; }

            [JsonProperty("video_view_count", NullValueHandling = NullValueHandling.Ignore)]
            public long? VideoViewCount { get; set; }

            [JsonProperty("accessibility_caption", NullValueHandling = NullValueHandling.Ignore)]
            public string AccessibilityCaption { get; set; }
        }

        public class EdgeMediaToCaption
        {
            [JsonProperty("edges")]
            public List<EdgeMediaToCaptionEdge> Edges { get; set; }
        }

        public class EdgeMediaToCaptionEdge
        {
            [JsonProperty("node")]
            public FluffyNode Node { get; set; }
        }

        public class FluffyNode
        {
            [JsonProperty("text")]
            public string Text { get; set; }
        }

        public class EdgeFollowClass
        {
            [JsonProperty("count")]
            public long Count { get; set; }
        }

        public class Dimensions
        {
            [JsonProperty("height")]
            public long Height { get; set; }

            [JsonProperty("width")]
            public long Width { get; set; }
        }

        public class Location
        {
            [JsonProperty("id")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Id { get; set; }

            [JsonProperty("has_public_page")]
            public bool HasPublicPage { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }
        }

        public class Owner
        {
            [JsonProperty("id")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Id { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }
        }

        public class ThumbnailResource
        {
            [JsonProperty("src")]
            public string Src { get; set; }

            [JsonProperty("config_width")]
            public long ConfigWidth { get; set; }

            [JsonProperty("config_height")]
            public long ConfigHeight { get; set; }
        }

        internal class PurpleParseStringConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (Int64.TryParse(value, out long l))
                {
                    return l;
                }

                throw new Exception("Cannot unmarshal type long");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }

                var value = (long) untypedValue;
                serializer.Serialize(writer, value.ToString());
            }

            public static readonly PurpleParseStringConverter Singleton = new PurpleParseStringConverter();
        }
    }
}