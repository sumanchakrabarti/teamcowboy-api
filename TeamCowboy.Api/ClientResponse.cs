using Newtonsoft.Json;

#if WINDOWS_UWP
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
#else
#endif

namespace TeamCowboy.Api
{
    public class ClientResponse<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("body")]
        public T Data { get; set; }
    }
}
