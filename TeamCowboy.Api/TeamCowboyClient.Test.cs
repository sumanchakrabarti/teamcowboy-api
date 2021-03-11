using System.Collections.Generic;
using System.Threading.Tasks;

using TeamCowboy.Api.Models;

namespace TeamCowboy.Api
{
    public partial class TeamCowboyClient
    {
        public async Task<TestResponse> TestGetRequestAsync(string testParam)
        {
            var properties = new Dictionary<string, string> { { nameof(testParam), testParam } };
            var response = await SendRequestAsync<TestResponse>("Test_GetRequest", properties);
            return response.Data;
        }

        public async Task<TestResponse> TestPostRequestAsync(string testParam)
        {
            var properties = new Dictionary<string, string> { { nameof(testParam), "this is a test" } };
            var response = await SendRequestAsync<TestResponse>("Test_PostRequest", properties, httpMethod: ClientRequestMethod.Post);
            return response.Data;
        }
    }
}
