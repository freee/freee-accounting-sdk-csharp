using System.Security.Claims;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;

namespace Freee.OAuth.AspNetCore
{
    public class FreeeAuthenticationOptions : OAuthOptions
    {
        public FreeeAuthenticationOptions()
        {
            ClaimsIssuer = FreeeAuthenticationDefaults.Issuer;

            CallbackPath = new PathString(FreeeAuthenticationDefaults.CallbackPath);

            AuthorizationEndpoint = FreeeAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = FreeeAuthenticationDefaults.TokenEndpoint;
            UserInformationEndpoint = FreeeAuthenticationDefaults.UserInformationEndpoint;

            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
            ClaimActions.MapJsonKey(ClaimTypes.GivenName, "first_name");
            ClaimActions.MapJsonKey(ClaimTypes.Surname, "last_name");
            ClaimActions.MapCustomJson(ClaimTypes.Name, x => (string)x["display_name"] ?? $"{x["last_name"]} {x["first_name"]}");
        }
    }
}
