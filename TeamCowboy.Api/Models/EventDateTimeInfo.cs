using Newtonsoft.Json;
using System;

namespace TeamCowboy.Api.Models
{
    public class EventDateTimeInfo
    {
        [JsonProperty("timezoneId")]
        public string TimezoneId { get; set; }

        [JsonProperty("startDateLocal")]
        public DateTime StartDateTimeLocal { get; set; }

        [JsonProperty("startDateTimeLocalDisplay")]
        public string StartDateTimeLocalDisplay { get; set; }

        [JsonProperty("startDateTimeUtc")]
        public DateTimeOffset StartDateTimeUtc { get; set; }

        [JsonProperty("endDateLocal")]
        public DateTime EndDateTimeLocal { get; set; }

        [JsonProperty("endDateTimeLocalDisplay")]
        public string EndDateTimeLocalDisplay { get; set; }

        [JsonProperty("endDateTimeUtc")]
        public DateTimeOffset EndDateTimeUtc { get; set; }

        [JsonProperty("inPast")]
        public bool InPast { get; set; }

        [JsonProperty("inFuture")]
        public bool InFuture { get; set; }
    }
}