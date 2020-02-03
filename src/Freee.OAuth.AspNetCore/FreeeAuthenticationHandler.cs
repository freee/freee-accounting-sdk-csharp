using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Freee.OAuth.AspNetCore
{
    public class FreeeAuthenticationHandler : OAuthHandler<FreeeAuthenticationOptions>
    {
        public FreeeAuthenticationHandler(IOptionsMonitor<FreeeAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Options.UserInformationEndpoint);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);

            var response = await Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, Context.RequestAborted);

            response.EnsureSuccessStatusCode();

            using (var payload = JsonDocument.Parse(await response.Content.ReadAsStringAsync()))
            {
                var userData = payload.RootElement.GetProperty("user");
                var context = new OAuthCreatingTicketContext(new ClaimsPrincipal(identity), properties, Context, Scheme, Options, Backchannel, tokens, userData);

                context.RunClaimActions();

                await Options.Events.CreatingTicket(context);

                return new AuthenticationTicket(context.Principal, context.Properties, Scheme.Name);
            }
        }
    }
}
