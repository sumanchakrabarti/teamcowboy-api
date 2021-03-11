using Newtonsoft.Json;

namespace TeamCowboy.Api.Models
{
    public class EventRsvpInstance
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("teamMemberType")]
        public TeamMemberType TeamMemberType { get; set; }

        [JsonProperty("rsvpDetails")]
        public EventRsvpDetails RsvpDetails { get; set; }
    }
}