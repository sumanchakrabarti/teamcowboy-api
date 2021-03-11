using Newtonsoft.Json;
namespace TeamCowboy.Api.Models
{
    public class SaveEventRsvpResponse
    {
        [JsonProperty("rsvpSaved")]
        public bool RsvpSaved { get; set; }

        [JsonProperty("statusCode")]
        public EventRsvpResponseStatus StatusCode { get; set; }
    }
}