using Newtonsoft.Json;
using System.Collections.Generic;

namespace TeamCowboy.Api.Models
{
    public class EventRsvpDetails
    {
        [JsonProperty("allowRsvp")]
        public bool AllowRsvp { get; set; }

        [JsonProperty("allowRsvpRemoval")]
        public bool AllowRsvpRemoval { get; set; }

        [JsonProperty("allowExtraPlayers")]
        public bool AllowExtraPlayers { get; set; }

        [JsonProperty("allowedStatuses")]
        public IEnumerable<EventRsvpStatus> AllowedStatuses { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusDisplay")]
        public string StatusDisplay { get; set; }

        [JsonProperty("addlMale")]
        public int AdditionalMaleCount { get; set; }

        [JsonProperty("addlMaleDisplay")]
        public string AdditionalMale { get; set; }

        [JsonProperty("addlFemale")]
        public int AdditionalFemaleCount { get; set; }

        [JsonProperty("addlFemaleDisplay")]
        public string AdditionalFemale { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }
    }
}