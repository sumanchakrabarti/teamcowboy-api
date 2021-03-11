using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamCowboy.Api.Models;

namespace TeamCowboy.Api
{
    public partial class TeamCowboyClient
    {
        public async Task<AuthenticationResult> GetUserTokenAsync(string username, string password)
        {
            var properties = new Dictionary<string, string> {
                { nameof(username), username },
                { nameof(password), password },
            };
            var response = await SendRequestAsync<AuthenticationResult>(
                "Auth_GetUserToken",
                properties,
                isHttps: true,
                httpMethod: ClientRequestMethod.Post);

            return response.Data;
        }

        public async Task<User> GetUserAsync(string userToken)
        {
            var properties = new Dictionary<string, string> {
                { nameof(userToken), userToken },
            };
            var response = await SendRequestAsync<User>(
                "User_Get",
                properties);

            return response.Data;
        }

        public async Task<IEnumerable<Team>> GetUserTeamsAsync(
            string userToken,
            bool? dashboardTeamsOnly = null)
        {
            var properties = new Dictionary<string, string> {
                { nameof(userToken), userToken },
                { nameof(dashboardTeamsOnly), dashboardTeamsOnly?.ToString() },
            };
            var response = await SendRequestAsync<IEnumerable<Team>>(
                "User_GetTeams",
                properties);

            return response.Data;
        }

        public async Task<IEnumerable<Event>> GetUserTeamEventsAsync(
            string userToken,
            DateTimeOffset? startDateTime = null,
            DateTimeOffset? endDateTime = null,
            int? teamId = null,
            bool? dashboardTeamsOnly = null)
        {
            var properties = new Dictionary<string, string> {
                { nameof(userToken), userToken },
                { nameof(startDateTime), startDateTime?.ToUniversalTime().ToString(DATETIME_FORMAT) },
                { nameof(endDateTime), endDateTime?.ToUniversalTime().ToString(DATETIME_FORMAT) },
                { nameof(teamId), teamId?.ToString() },
                { nameof(dashboardTeamsOnly), dashboardTeamsOnly?.ToString() },
            };
            var response = await SendRequestAsync<IEnumerable<Event>>(
                "User_GetTeamEvents",
                properties);

            return response.Data;
        }
    }
}
