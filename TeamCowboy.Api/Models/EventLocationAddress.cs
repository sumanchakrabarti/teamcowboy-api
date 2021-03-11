using Newtonsoft.Json;
namespace TeamCowboy.Api.Models
{
    public class EventLocationAddress
    {
        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("addressLine2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("stateProvince")]
        public string StateProvince { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("partOfTown")]
        public string PartOfTown { get; set; }

        [JsonProperty("displayMultiLine")]
        public string DisplayMultiLine { get; set; }

        [JsonProperty("displaySingleLine")]
        public string DisplaySingleLine { get; set; }

        [JsonProperty("googleMapsUrl")]
        public string GoogleMapsUrl { get; set; }

        [JsonProperty("googleMapsDirectionsUrl")]
        public string GoogleMapsDirectionsUrl { get; set; }
    }
}