using Newtonsoft.Json;
namespace TeamCowboy.Api.Models
{
    public class TeamMemberType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("titleLongSingular")]
        public string TitleLongSingular { get; set; }

        [JsonProperty("titleLongPlural")]
        public string TitleLongPlural { get; set; }

        [JsonProperty("titleShortSingular")]
        public string TitleShortSingular { get; set; }

        [JsonProperty("titleShortPlural")]
        public string TitleShortPlural { get; set; }

        [JsonProperty("showTeamMembersOnRoster")]
        public bool ShowTeamMembersOnRoster { get; set; }

        [JsonProperty("showTeamMembersOnAttList")]
        public bool ShowTeamMembersOnAttList { get; set; }

        [JsonProperty("showTitleOnAttList")]
        public bool ShowTitleOnAttList { get; set; }
    }
}