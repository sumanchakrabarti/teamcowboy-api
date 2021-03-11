using Newtonsoft.Json;
using System.Collections.Generic;

namespace TeamCowboy.Api.Models
{
    public class ColorSwatch
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("colorCount")]
        public int ColorCount { get; set; }

        [JsonProperty("colors")]
        public IEnumerable<Color> Colors { get; set; }
    }

    public class Color
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("hexCode")]
        public string HexCode { get; set; }
    }
}