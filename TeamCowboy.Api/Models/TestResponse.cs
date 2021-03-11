using Newtonsoft.Json;

namespace TeamCowboy.Api.Models
{
    public class TestResponse
    {
        [JsonProperty("helloWorld")]
        public string HelloWorld { get; set; }
    }
}
