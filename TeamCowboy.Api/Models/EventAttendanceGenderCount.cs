using Newtonsoft.Json;

namespace TeamCowboy.Api.Models
{
    public class EventAttendanceGenderCount
    {
        [JsonProperty("m")]
        public int Males { get; set; }

        [JsonProperty("f")]
        public int Females { get; set; }

        [JsonProperty("other")]
        public int Other { get; set; }
    }
}
