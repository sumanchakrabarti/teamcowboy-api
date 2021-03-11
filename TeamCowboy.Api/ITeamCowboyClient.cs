using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamCowboy.Api.Models;

namespace TeamCowboy.Api
{
    public interface ITeamCowboyClient
    {
        Task<Event> GetEventAsync(string userToken, int teamId, int eventId, bool? includeRSVPInfo = null);
        Task<Event> GetEventAttendanceAsync(string userToken, int teamId, int eventId);
        Task<Team> GetTeamAsync(string userToken, int teamId);
        Task<IEnumerable<Event>> GetTeamEventsAsync(string userToken, int teamId, bool? includeRSVPInfo = null, int? seasonId = null, TeamEventsFilter? filter = null, DateTime? startDateTime = null, DateTime? endDateTime = null, uint? offset = null, uint? qty = null);
        Task<IEnumerable<Message>> GetTeamMessagesAsync(string userToken, int teamId, int? messageId = null, uint? offset = null, uint? qty = null, TeamMessagesSortBy? sortBy = null, SortDirection? sortDirection = null);
        Task<IEnumerable<User>> GetTeamRosterAsync(string userToken, int teamId, int? userId = null, bool? includeInactive = null, TeamRosterSortBy? sortBy = null, SortDirection? sortDirection = null);
        //Task<IEnumerable<Season>> GetTeamSeasonsAsync(string userToken, int teamId);
        Task<User> GetUserAsync(string userToken);
        Task<IEnumerable<Team>> GetUserTeamsAsync(string userToken, bool? dashboardTeamsOnly = null);
        Task<IEnumerable<Event>> GetUserTeamEventsAsync(string userToken, DateTimeOffset? startDateTime = null, DateTimeOffset? endDateTime = null, int? teamId = null, bool? dashboardTeamsOnly = null);
        Task<AuthenticationResult> GetUserTokenAsync(string username, string password);
        Task<SaveEventRsvpResponse> SaveEventRsvp(string userToken, int teamId, int eventId, EventRsvpStatus status, int? addlMale = null, int? addlFemale = null, string comments = null, int? rsvpAsUserId = null);
        Task<TestResponse> TestGetRequestAsync(string testParam);
        Task<TestResponse> TestPostRequestAsync(string testParam);
    }
}