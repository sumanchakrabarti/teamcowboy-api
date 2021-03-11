using System.Collections.Generic;
using System.Threading.Tasks;

using TeamCowboy.Api.Models;

namespace TeamCowboy.Api
{
    public partial class TeamCowboyClient
    {
        public async Task<Event> GetEventAsync(string userToken, int teamId, int eventId, bool? includeRSVPInfo = null)
        {
            var properties = new Dictionary<string, string> {
                { nameof(userToken), userToken },
                { nameof(teamId), teamId.ToString() },
                { nameof(eventId), eventId.ToString() },
                { nameof(includeRSVPInfo), includeRSVPInfo?.ToString() },
            };
            var response = await SendRequestAsync<Event>("Event_Get", properties);
            return response.Data;
        }

        public async Task<Event> GetEventAttendanceAsync(string userToken, int teamId, int eventId)
        {
            var properties = new Dictionary<string, string> {
                { nameof(userToken), userToken },
                { nameof(teamId), teamId.ToString() },
                { nameof(eventId), eventId.ToString() },
            };
            var response = await SendRequestAsync<Event>("Event_GetAttendanceList", properties);
            return response.Data;
        }

        public async Task<SaveEventRsvpResponse> SaveEventRsvp(
            string userToken,
            int teamId,
            int eventId,
            EventRsvpStatus status,
            int? addlMale = null,
            int? addlFemale = null,
            string comments = null,
            int? rsvpAsUserId = null)
        {
            var properties = new Dictionary<string, string> {
                { nameof(userToken), userToken },
                { nameof(teamId), teamId.ToString() },
                { nameof(eventId), eventId.ToString() },
                { nameof(status), status.ToString().ToLower() },
                { nameof(addlMale), addlMale?.ToString() },
                { nameof(addlFemale), addlFemale?.ToString() },
                { nameof(comments), comments?.ToString() },
                { nameof(rsvpAsUserId), rsvpAsUserId?.ToString() },
            };
            var response = await SendRequestAsync<SaveEventRsvpResponse>("Event_SaveRSVP", properties, httpMethod: ClientRequestMethod.Post);
            return response.Data;
        }
    }
}
