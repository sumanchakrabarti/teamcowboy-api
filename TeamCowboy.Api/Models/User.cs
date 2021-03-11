using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamCowboy.Api.Models
{
    public class User
    {
        //userId
        [JsonProperty("userId")]
        public int UserId { get; set; }
        //firstName
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        //lastName
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        //fullName
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        //displayName
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        //emailAddress1
        [JsonProperty("emailAddress1")]
        public string EmailAddress1 { get; set; }
        //emailAddress2
        [JsonProperty("emailAddress2")]
        public string EmailAddress2{ get; set; }
        //phone1
        [JsonProperty("phone1")]
        public string Phone1 { get; set; }
        //phone2
        [JsonProperty("phone2")]
        public string Phone2 { get; set; }
        //gender
        [JsonProperty("gender")]
        public string Gender { get; set; }
        //genderDisplay
        [JsonProperty("genderDisplay")]
        public string GenderDisplay { get; set; }
        //birthDate_month
        [JsonProperty("birthDate_month")]
        public int? BirthDateMonth { get; set; }
        //birthDate_day
        [JsonProperty("birthDate_day")]
        public int? BirthDateDay { get; set; }
        //birthDate_year
        [JsonProperty("birthDate_year")]
        public int? BirthDateYear { get; set; }
        //shirtNumber
        [JsonProperty("shirtNumber")]
        public string ShirtNumber { get; set; }
        //shirtSize
        [JsonProperty("shirtSize")]
        public string ShirtSize { get; set; }
        //pantsSize
        [JsonProperty("pantsSize")]
        public string PantsSize { get; set; }
        //options
        [JsonProperty("options")]
        public JObject Options { get; set; }
        //profilePhoto
        [JsonProperty("profilePhoto")]
        public Photo ProfilePhoto { get; set; }
        //teamMeta
        [JsonProperty("teamMeta")]
        public JObject TeamMeta { get; set; }
        //linkedUsers
        [JsonProperty("linkedUsers")]
        public string LinkedUsers { get; set; }
        //dateCreatedUtc
        [JsonProperty("dateCreatedUtc")]
        public string DateCreatedUtc { get; set; }
        //dateLastUpdatedUtc
        [JsonProperty("dateLastUpdatedUtc")]
        public string DateLastUpdatedUtc { get; set; }
        //dateLastSignInUtc
        [JsonProperty("dateLastSignInUtc")]
        public string DateLastSignInUtc { get; set; }
    }
}
