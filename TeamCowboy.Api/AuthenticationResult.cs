using Newtonsoft.Json;

namespace TeamCowboy.Api
{
    public class AuthenticationResult
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
