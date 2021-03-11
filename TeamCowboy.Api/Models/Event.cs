using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace TeamCowboy.Api.Models
{
    public class Event
    {
        //eventId
        [JsonProperty("eventId")]
        public int EventId { get; set; }
        //team
        [JsonProperty("team")]
        public Team Team { get; set; }
        //seasonId
        [JsonProperty("seasonId")]
        public int SeasonId { get; set; }
        //seasonName
        [JsonProperty("seasonName")]
        public string SeasonName { get; set; }
        //eventType
        [JsonProperty("eventType")]
        public string EventType { get; set; }
        //eventTypeDisplay
        [JsonProperty("eventTypeDisplay")]
        public string EventTypeDisplay { get; set; }
        //status
        [JsonProperty("status")]
        public EventStatus Status { get; set; }
        //statusDisplay
        [JsonProperty("statusDisplay")]
        public string StatusDisplay { get; set; }
        //personNounSingular
        [JsonProperty("personNounSingular")]
        public string PersonNounSingular { get; set; }
        //personNounPlural
        [JsonProperty("personNounPlural")]
        public string PersonNounPlural { get; set; }
        //title
        [JsonProperty("title")]
        public string Title { get; set; }
        //titleFull
        [JsonProperty("titleFull")]
        public string TitleFull { get; set; }
        //titleLabel
        [JsonProperty("titleLabel")]
        public string TitleLabel { get; set; }
        //homeAway
        [JsonProperty("homeAway")]
        public IsHomeAway? HomeAway { get; set; }
        //result
        [JsonProperty("result")]
        public EventResult Result { get; set; }
        //rsvpInstances
        [JsonProperty("rsvpInstances")]
        public IEnumerable<EventRsvpInstance> RsvpInstances { get; set; }
        //comments
        [JsonProperty("comments")]
        public string Comments { get; set; }
        //options
        [JsonProperty("options")]
        public JObject Options { get; set; }
        //oneLineDisplay
        [JsonProperty("oneLineDisplay")]
        public string OneLineDisplay { get; set; }
        //oneLineDisplayShort
        [JsonProperty("oneLineDisplayShort")]
        public string OneLineDisplayShort { get; set; }
        //maleGenderDisplay
        [JsonProperty("maleGenderDisplay")]
        public string MaleGenderDisplay { get; set; }
        //femaleGenderDisplay
        [JsonProperty("femaleGenderDisplay")]
        public string FemaleGenderDisplay { get; set; }
        //dateTimeInfo
        [JsonProperty("dateTimeInfo")]
        public EventDateTimeInfo DateTimeInfo { get; set; }
        //location
        [JsonProperty("location")]
        public EventLocation Location { get; set; }
        //shirtColors
        [JsonProperty("shirtColors")]
        public EventShirtColors ShirtColors { get; set; }
        //userMetaInfo
        [JsonProperty("userMetaInfo")]
        public EventUserMetaInfo UserMetaInfo { get; set; }
        //dateCreatedUtc
        [JsonProperty("dateCreatedUtc")]
        public DateTimeOffset DateCreatedUtc { get; set; }
        //dateLastUpdatedUtc
        [JsonProperty("dateLastUpdatedUtc")]
        public DateTimeOffset DateLastUpdatedUtc { get; set; }
    }
}
