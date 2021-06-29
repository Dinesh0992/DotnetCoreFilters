using System;
using System.Security.Claims;

namespace DotnetCoreFilters.TokenAuthentication
{
    public interface ITokenManager
    {
        bool Authenticate(string userName, string password);
        string NewToken();
        ClaimsPrincipal VerifyToken(string Token);
    }
}

