#if WINDOWS_UWP
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
#else
#endif

namespace TeamCowboy.Api
{
    public enum ClientRequestMethod
    {
        Get,
        Post
    }
}
