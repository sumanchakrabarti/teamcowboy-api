using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TeamCowboy.Api;

namespace TeamCowboy.ApiTests
{
    [TestClass]
    public class TeamCowboyClientTests
    {
        private static readonly TeamCowboyClientOptions Options = new TeamCowboyClientOptions
        {
            ApiKey = "api_key",
            ApiSecret = "api_secret"
        };

        [TestClass]
        public class when_creating_signature : TeamCowboyClientTests
        {
            [TestMethod]
            public void it_should_generate_valid_signature()
            {
                var teamCowboyClient = new TeamCowboyClient(Options);
                var properties = new Dictionary<string, string>()
                {
                    { "teamId", "1234" },
                    { "userToken", "0bd5a0ed9ff7f4c59e1854b63b341a8f" }
                };

                var actual = teamCowboyClient.CreateSignature(
                    "Team_Get",
                    properties,
                    httpMethod: "GET",
                    responseType: "json",
                    nonce: "5646464564",
                    timestamp: "1296268551");

                var expected = $"{Options.ApiSecret}|GET|Team_Get|1296268551|5646464564|" +
                    $"api_key={Options.ApiKey}" +
                    "&method=team_get" +
                    "&nonce=5646464564" +
                    "&response_type=json" +
                    "&teamid=1234" +
                    "&timestamp=1296268551" +
                    "&usertoken=0bd5a0ed9ff7f4c59e1854b63b341a8f";

                System.Diagnostics.Debug.WriteLine($"A: {actual}");
                System.Diagnostics.Debug.WriteLine($"E: {expected}");

                if (actual.Length == expected.Length)
                {
                    for (var i = 0; i < actual.Length; i++)
                    {
                        var isEqual = actual[i] == expected[i];
                        if (!isEqual)
                        {
                            System.Diagnostics.Debug.WriteLine($"Not matched at: {i}: {actual[i]} {expected[i]}");
                            break;
                        }
                    }
                }

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void it_should_hash_signature()
            {
                var signature =
                    "api_key|GET|Team_Get|1296268551|5646464564|" +
                    "api_key=api_secret&" +
                    "method=team_get&" +
                    "nonce=5646464564&" +
                    "teamid=1234&" +
                    "timestamp=1296268551&" +
                    "usertoken=0bd5a0ed9ff7f4c59e1854b63b341a8f";
                var expected = "7f7c978c03872201da37275b1a411ccef812abab";

                var actual = TeamCowboyClient.HashSignature(signature);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
