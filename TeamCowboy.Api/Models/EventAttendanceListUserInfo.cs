using Newtonsoft.Json;
using System;

namespace TeamCowboy.Api.Models
{
    public class EventAttendanceListUserInfo
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusDisplay")]
        public string StatusDisplay { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("canRSVP")]
        public bool CanRsvp { get; set; }

        [JsonProperty("hasResponded")]
        public bool HasResponded { get; set; }

        [JsonProperty("addlMale")]
        public int AdditionalMale { get; set; }

        [JsonProperty("addlFemale")]
        public int AdditionalFemale { get; set; }

        [JsonProperty("addlDisplay")]
        public string AdditionalDisplay { get; set; }

        [JsonProperty("dateCreatedLocal")]
        public DateTime DateCreatedLocal { get; set; }

        [JsonProperty("dateLastUpdatedLocal")]
        public DateTime DateLastUpdatedLocal { get; set; }

        [JsonProperty("dateCreatedUtc")]
        public DateTime DateCreatedUtc { get; set; }

        [JsonProperty("dateLastUpdatedUtc")]
        public DateTime DateLastUpdatedUtc { get; set; }
    }
}