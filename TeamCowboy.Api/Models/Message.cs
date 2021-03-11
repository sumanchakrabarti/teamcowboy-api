using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace TeamCowboy.Api.Models
{
    public class Message
    {
        //messageId
        [JsonProperty("messageId")]
        public int MessageId { get; set; }
        //title
        [JsonProperty("title")]
        public string Title { get; set; }
        //bodyHtml
        [JsonProperty("bodyHtml")]
        public string BodyHtml { get; set; }
        //bodyText
        [JsonProperty("bodyText")]
        public string BodyText { get; set; }
        //isPinned
        [JsonProperty("isPinned")]
        public bool IsPinned { get; set; }
        //allowComments
        [JsonProperty("allowComments")]
        public bool AllowComments { get; set; }
        //commentCount
        [JsonProperty("commentCount")]
        public int CommentCount { get; set; }
        //team
        [JsonProperty("team")]
        public Team Team { get; set; }
        //postedBy
        [JsonProperty("postedBy")]
        public User PostedBy { get; set; }
        //comments
        [JsonProperty("comments")]
        public string Comments { get; set; }
        //userMetaInfo
        [JsonProperty("userMetaInfo")]
        public JObject UserMetaInfo { get; set; }
        //dateCreatedLocal
        [JsonProperty("dateCreatedLocal")]
        public DateTime DateCreatedLocal { get; set; }
        //dateLastUpdatedLocal
        [JsonProperty("dateLastUpdatedLocal")]
        public DateTime DateLastUpdatedLocal { get; set; }
        //dateCreatedUtc
        [JsonProperty("dateCreatedUtc")]
        public DateTimeOffset DateCreatedUtc { get; set; }
        //dateLastUpdatedUtc
        [JsonProperty("dateLastUpdatedUtc")]
        public DateTimeOffset DateLastUpdatedUtc { get; set; }

    }
}