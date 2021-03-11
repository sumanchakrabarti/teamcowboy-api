using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TeamCowboy.Api.Models;

namespace TeamCowboy.Api
{
    public partial class TeamCowboyClient
    {
        public async Task<Team> GetTeamAsync(string userToken, int teamId)
        {
            var properties = new Dictionary<string, string> {
                { nameof(userToken), userToken },
                { nameof(teamId), teamId.ToString() }
            };
            var response = await SendRequestAsync<Team>("Team_Get", properties);
            return response.Data;
        }

        public async Task<IEnumerable<Event>> GetTeamEventsAsync(
            string userToken,
            int teamId,
            bool? includeRSVPInfo = null,
            int? seasonId = null,
            TeamEventsFilter? filter = null,
            DateTime? startDateTime = null,
            DateTime? endDateTime = null,
            uint? offset = null,
            uint? qty = null)
        {
            var properties = new Dictionary<string, string> {
                { nameof(userToken), userToken },
                { nameof(teamId), teamId.ToString() },
                { nameof(includeRSVPInfo), includeRSVPInfo?.ToString() },
                { nameof(seasonId), seasonId?.ToString() },
                { nameof(filter), ToCamelCase(filter) },
                { nameof(startDateTime), startDateTime?.ToString("YYYY-MM-DD HH:MM:SS") },
                { nameof(endDateTime), endDateTime?.ToString("YYYY-MM-DD HH:MM:SS") },
                { nameof(offset), offset?.ToString() },
                { nameof(qty), qty?.ToString() },
            };
            var response = await SendRequestAsync<IEnumerable<Event>>("Team_GetEvents", properties);
            return response.Data;
        }

        public async Task<IEnumerable<Message>> GetTeamMessagesAsync(
            string userToken,
            int teamId,
            int? messageId = null,
            uint? offset = null,
            uint? qty = null,
            TeamMessagesSortBy? sortBy = null,
            SortDirection? sortDirection = null)
        {
            var properties = new Dictionary<string, string> {
                { nameof(userToken), userToken },
                { nameof(teamId), teamId.ToString() },
                { nameof(messageId), messageId?.ToString() },
                { nameof(offset), offset?.ToString() },
                { nameof(qty), qty?.ToString() },
                { nameof(sortBy), ToCamelCase(sortBy) },
                { nameof(sortDirection), sortDirection?.ToString().ToUpper() },
            };
            var response = await SendRequestAsync<IEnumerable<Message>>("Team_GetMessages", properties);
            return response.Data;
        }

        public async Task<IEnumerable<User>> GetTeamRosterAsync(
            string userToken,
            int teamId,
            int? userId = null,
            bool? includeInactive = null,
            TeamRosterSortBy? sortBy = null,
            SortDirection? sortDirection = null)
        {
            var properties = new Dictionary<string, string> {
                { nameof(userToken), userToken },
                { nameof(teamId), teamId.ToString() },
                { nameof(userId), userId?.ToString() },
                { nameof(includeInactive), includeInactive?.ToString() },
                { nameof(sortBy), ToCamelCase(sortBy) },
                { nameof(sortDirection), sortDirection?.ToString().ToUpper() },
            };
            var response = await SendRequestAsync<IEnumerable<User>>("Team_GetRoster", properties);
            return response.Data;
        }

        //public async Task<IEnumerable<Season>> GetTeamSeasonsAsync(
        //    string userToken,
        //    int teamId)
        //{
        //    var properties = new Dictionary<string, string> {
        //        { nameof(userToken), userToken },
        //        { nameof(teamId), teamId.ToString() }
        //    };
        //    var response = await SendRequestAsync<IEnumerable<Message>>("Team_GetSeasons", properties);
        //    return response.Data;
        //}

        private static string ToCamelCase<T>(T? input) where T : struct
        {
            if (!input.HasValue) return null;

            var inputString = input.ToString();

            var firstChar = inputString.Substring(0, 1).ToLower();
            return firstChar + inputString.Substring(1);
        }
    }
}
