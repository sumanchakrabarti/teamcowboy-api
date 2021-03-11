using Newtonsoft.Json;
namespace TeamCowboy.Api.Models
{
    public class EventUserMetaInfo
    {
        [JsonProperty("isTeamAdmin")]
        public bool IsTeamAdmin { get; set; }

        [JsonProperty("showOnDashboard")]
        public bool ShowOnDashboard { get; set; }
    }
}