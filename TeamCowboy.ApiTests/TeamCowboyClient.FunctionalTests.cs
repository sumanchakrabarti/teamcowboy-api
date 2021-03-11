using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamCowboy.Api.Tests
{
    [TestClass()]
    public class TeamCowboyClientFunctionalTests
    {
        private static readonly TeamCowboyClientOptions Options = new TeamCowboyClientOptions
        {
            ApiKey = "<api_key>",
            ApiSecret = "<api_secret>"
        };

        [TestClass]
        public class when_creating_signature : TeamCowboyClientFunctionalTests
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
                var signature = $"{Options.ApiSecret}|GET|Team_Get|1296268551|5646464564|" +
                   $"api_key={Options.ApiKey}&" +
                    "method=team_get&" +
                    "nonce=5646464564&" +
                    "teamid=1234&" +
                    "timestamp=1296268551&" +
                    "usertoken=0bd5a0ed9ff7f4c59e1854b63b341a8f";
                var expected = "ab6cdb8d0bd75069a6d11c52f4157ddc0cf860f5";

                var actual = TeamCowboyClient.HashSignature(signature);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass]
        public class when_running_live_test : TeamCowboyClientFunctionalTests
        {
            private const string username = "username@domain.com";
            private const string password = "password";
            private const int teamId = 24736;

            [TestMethod]
            public async Task it_should_get_test_get_request()
            {
                var client = new TeamCowboyClient(Options);
                var result = await client.TestGetRequestAsync("this is a test");

                Assert.AreEqual("You successfully called the test method! The value you passed in for 'testParam' was: this is a test", result.HelloWorld);
            }

            [TestMethod]
            public async Task it_should_get_test_post_request()
            {
                var client = new TeamCowboyClient(Options);
                var result = await client.TestPostRequestAsync("this is a test");

                Assert.AreEqual("You successfully called the test method! The value you passed in for 'testParam' was: this is a test", result.HelloWorld);
            }

            [TestMethod]
            public async Task it_should_get_auth_token()
            {
                var client = new TeamCowboyClient(Options);
                var result = await client.GetUserTokenAsync(username, password);

                Assert.AreEqual(431672, result.UserId);
                Assert.IsNotNull(result.Token);
            }

            [TestMethod]
            public async Task it_should_get_user()
            {
                var client = new TeamCowboyClient(Options);
                var authToken = await client.GetUserTokenAsync(username, password);
                var result = await client.GetUserAsync(authToken.Token);

                Assert.AreEqual(431672, result.UserId);
                Assert.AreEqual("Suman", result.FirstName);
                Assert.AreEqual("Chakrabarti", result.LastName);
            }

            [TestMethod]
            public async Task it_should_get_team()
            {
                var client = new TeamCowboyClient(Options);
                var authToken = await client.GetUserTokenAsync(username, password);
                var result = await client.GetTeamAsync(authToken.Token, teamId);

                Assert.AreEqual(teamId, result.TeamId);
                Assert.AreEqual("Team 1", result.Name);
            }

            [TestMethod]
            public async Task it_should_get_teams()
            {
                var client = new TeamCowboyClient(Options);
                var authToken = await client.GetUserTokenAsync(username, password);
                var result = await client.GetUserTeamsAsync(authToken.Token);

                Assert.IsNotNull(result);
                Assert.AreEqual(1, result.Count());
            }

            [TestMethod]
            public async Task it_should_get_team_messages()
            {
                var client = new TeamCowboyClient(Options);
                var authToken = await client.GetUserTokenAsync(username, password);
                var result = (await client.GetTeamMessagesAsync(authToken.Token, teamId)).ToList();

                Assert.AreEqual(133819, result[0].MessageId);
                Assert.AreEqual("Testing a message", result[0].Title);
            }
        }
    }
}