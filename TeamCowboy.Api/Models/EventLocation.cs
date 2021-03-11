using Newtonsoft.Json;
namespace TeamCowboy.Api.Models
{
    public class EventLocation
    {
        [JsonProperty("locationId")]
        public int locationId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public EventLocationAddress Address { get; set; }

        [JsonProperty("visibity")]
        public string Visibity { get; set; }

        [JsonProperty("visibityDisplay")]
        public string VisibityDisplay { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }
    }
}