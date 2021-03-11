using Newtonsoft.Json;

namespace TeamCowboy.Api.Models
{
    public class EventResult
    {
        [JsonProperty("scopeEntered")]
        public bool ScopeEntered { get; set; } = false;

        [JsonProperty("outcome")]
        public EventOutcome? Outcome { get; set; }

        [JsonProperty("score1")]
        public int Score1 { get; set; }

        [JsonProperty("score2")]
        public int Score2 { get; set; }

        [JsonProperty("isWin")]
        public bool IsWin { get; set; }

        [JsonProperty("isLoss")]
        public bool IsLoss { get; set; }

        [JsonProperty("isTie")]
        public bool IsTie { get; set; }

        [JsonProperty("scoreDisplay")]
        public string ScoreDisplay { get; set; }
    }
}
