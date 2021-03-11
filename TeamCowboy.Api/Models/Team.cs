using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamCowboy.Api.Models
{
    public class Team
    {
        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("type")]
        public TeamType Type { get; set; }

        [JsonProperty("activity")]
        public TeamActivity Activity { get; set; }

        [JsonProperty("timezoneId")]
        public string TimezoneId { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("stateProvince")]
        public string StateProvince { get; set; }

        [JsonProperty("stateProvinceAbbrev")]
        public string StateProvinceAbbreviation { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("countryIso3")]
        public string CountryIso3 { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("locationDisplayShort")]
        public string LocationDisplayShort { get; set; }

        [JsonProperty("locationDisplayLong")]
        public string LocationDisplayLong { get; set; }

        [JsonProperty("teamPhoto")]
        public Photo TeamPhoto { get; set; }

        [JsonProperty("colorSwatches")]
        public TeamColorSwatches ColorSwatches { get; set; }

        [JsonProperty("options")]
        public JObject Options { get; set; }

        //dateCreatedUtc
        [JsonProperty("dateCreatedUtc")]
        public DateTimeOffset DateCreatedUtc { get; set; }

        //dateLastUpdatedUtc
        [JsonProperty("dateLastUpdatedUtc")]
        public DateTimeOffset DateLastUpdatedUtc { get; set; }
    }

    public class TeamType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class TeamActivity
    {
        [JsonProperty("activityId")]
        public int ActivityId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
