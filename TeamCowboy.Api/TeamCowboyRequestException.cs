using System;

#if WINDOWS_UWP
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
#else
#endif

namespace TeamCowboy.Api
{
    public class TeamCowboyRequestException : Exception
    {
        public TeamCowboyRequestException() { }
        public TeamCowboyRequestException(string message) : base(message) { }
        public TeamCowboyRequestException(string message, Exception inner) : base(message, inner) { }
    }
}
