using Newtonsoft.Json;
namespace TeamCowboy.Api.Models
{
    public class EventShirtColors
    {
        [JsonProperty("team1")]
        public ColorSwatch Team1 { get; set; }

        [JsonProperty("team2")]
        public ColorSwatch Team2 { get; set; }
    }
}