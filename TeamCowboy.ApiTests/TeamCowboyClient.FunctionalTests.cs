using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using TeamCowboy.Api;

namespace TeamCowboy.ApiTests.Functional
{
    [TestClass()]
    public class TeamCowboyClientFunctionalTests
    {
        private static readonly TeamCowboyClientOptions Options = new TeamCowboyClientOptions
        {
            ApiKey = "api_key",
            ApiSecret = "api_secret"
        };

        [TestClass]
        [Ignore]
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