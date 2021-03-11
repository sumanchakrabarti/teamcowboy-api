using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Collections.Generic;

namespace TeamCowboy.Api.Models
{
    public class EventAttendanceList
    {
        [JsonProperty("countsByStatus")]
        public EventAttendanceCounts CountsByStatus { get; set; }

        [JsonProperty("meta")]
        public JObject Metadata { get; set; }

        [JsonProperty("users")]
        public IEnumerable<EventUserRsvp> Users { get; set; }
    }
}
