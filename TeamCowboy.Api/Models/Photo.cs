using Newtonsoft.Json;

namespace TeamCowboy.Api.Models
{
    public class Photo
    {
        [JsonProperty("fullUrl")]
        public string FullUrl { get; set; }

        [JsonProperty("smallUrl")]
        public string SmallUrl { get; set; }

        [JsonProperty("thumbUrl")]
        public string ThumbUrl { get; set; }
    }
}
