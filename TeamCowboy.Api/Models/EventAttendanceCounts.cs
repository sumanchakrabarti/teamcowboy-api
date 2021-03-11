using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TeamCowboy.Api.Models
{
    public class EventAttendanceCounts
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("byGender")]
        public EventAttendanceGenderCount ByGender { get; set; }

        [JsonProperty("byType")]
        public JObject ByType { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
