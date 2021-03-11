using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TeamCowboy.Api
{
    public partial class TeamCowboyClient : ITeamCowboyClient
    {
        const string ENDPOINT_URL = "://api.teamcowboy.com/v1/";
        const string DATETIME_FORMAT = "YYYY-MM-DD HH:MM:SS";

        #region [ Constructor ]
        public TeamCowboyClient(TeamCowboyClientOptions options)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }
        #endregion

        #region [ Properties ]
        public TeamCowboyClientOptions Options { get; }
        #endregion

        #region [ GetTimeStamp ]
        private static string GetTimeStamp()
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        #endregion

        #region [ GetNonce ]
        private static string GetNonce()
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(DateTime.Now.Ticks.ToString()));
        }
        #endregion

        #region [ SendRequestAsync ]
        private async Task<ClientResponse<T>> SendRequestAsync<T>(
            string apiMethod,
            IDictionary<string, string> properties,
            bool isHttps = false,
            ClientRequestMethod httpMethod = ClientRequestMethod.Get,
            string responseType = "json")
        {
            var client = new HttpClient();
            var url = $"http{(isHttps ? "s" : "")}{ENDPOINT_URL}";
            var queryString = BuildQueryString(apiMethod, httpMethod.ToString().ToUpper(), responseType, properties);

            switch (httpMethod.ToString().ToUpper())
            {
                case "GET":
                    url += $"?{queryString}";
                    var responseGet = await client.GetAsync(new Uri(url)).ConfigureAwait(false);
                    var getContent = await responseGet.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (responseGet.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<ClientResponse<T>>(getContent);
                    }
                    else
                    {
                        throw new TeamCowboyRequestException($"Method failed {apiMethod}\r\n{getContent}");
                    }
                case "POST":
                    var responsePost = await client.PostAsync(new Uri(url), new StringContent(queryString, Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);
                    var postContent = await responsePost.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (responsePost.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<ClientResponse<T>>(postContent);
                    }
                    else
                    {
                        throw new TeamCowboyRequestException($"Method failed {apiMethod}\r\n{postContent}");
                    }
                default:
                    throw new TeamCowboyRequestException($"Invalid HTTP method {httpMethod} for {apiMethod}");
            }
        }
        #endregion

        #region [ BuildQueryString ]
        private string BuildQueryString(string apiMethod, string httpMethod, string responseType, IDictionary<string, string> properties)
        {
            var allProperties = BuildQueryDictionary(apiMethod, httpMethod, responseType, properties);

            var qs = new StringBuilder();

            foreach (var key in properties.Keys)
            {
                qs.Append($"{key}={properties[key]}&");
            }

            return qs.ToString().Replace(" ", "+").TrimEnd('&');
        }
        #endregion

        #region [ BuildQueryDictionary ]
        private IDictionary<string, string> BuildQueryDictionary(string apiMethod, string httpMethod, string responseType, IDictionary<string, string> properties)
        {
            var timestamp = GetTimeStamp();
            var nonce = GetNonce();

            var signature = CreateSignature(apiMethod, properties, httpMethod, responseType, timestamp, nonce);
            properties.Add("sig", HashSignature(signature));

            return properties;
        }
        #endregion

        #region [ CreateSignature ]
        public string CreateSignature(
            string apiMethod,
            IDictionary<string, string> properties,
            string httpMethod,
            string responseType,
            string timestamp,
            string nonce)
        {
            properties.Add("api_key", Options.ApiKey);
            properties.Add("timestamp", timestamp.ToString());
            properties.Add("nonce", nonce);
            properties.Add("method", apiMethod);
            properties.Add("response_type", responseType);

            var signature = new StringBuilder();
            signature.Append($"{Options.ApiSecret}|{httpMethod}|{apiMethod}|{timestamp}|{nonce}|");

            foreach (var key in properties.Keys.OrderBy(k => k))
            {
                var value = properties[key] != null ? Uri.EscapeDataString(properties[key]).ToLower() : null;
                signature.Append($"{key.ToLower()}={value}&");
            }
            var result = signature.ToString().Replace("+", "%20").TrimEnd('&');
            return result;
        }
        #endregion

        #region [ HashSignature ]
        public static string HashSignature(string signature)
        {
            var sb = new StringBuilder();
            var result = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(signature));

            foreach (var byteData in result)
            {
                sb.Append(byteData.ToString("x2"));
            }
            var hash = sb.ToString();

            return hash;
        }
        #endregion
    }
}
