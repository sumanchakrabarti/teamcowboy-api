using Newtonsoft.Json;
namespace TeamCowboy.Api.Models
{
    public class TeamColorSwatches
    {
        [JsonProperty("home")]
        public ColorSwatch Home { get; set; }

        [JsonProperty("away")]
        public ColorSwatch Away { get; set; }

        [JsonProperty("alternate")]
        public ColorSwatch Alternate { get; set; }
    }
}