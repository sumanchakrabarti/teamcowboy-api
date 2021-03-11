#if WINDOWS_UWP
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
#else
#endif

namespace TeamCowboy.Api
{
    public class TeamCowboyClientOptions
    {
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
    }
}
