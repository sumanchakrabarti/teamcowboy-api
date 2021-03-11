using Newtonsoft.Json;

namespace TeamCowboy.Api.Models
{
    public class EventUserRsvp
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("rsvpInfo")]
        public EventAttendanceListUserInfo rsvpInfo { get; set; }
    }
}
