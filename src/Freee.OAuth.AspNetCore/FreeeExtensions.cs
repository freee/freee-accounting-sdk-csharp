using System;

using Freee.OAuth.AspNetCore;

using Microsoft.AspNetCore.Authentication;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FreeeExtensions
    {
        public static AuthenticationBuilder AddFreee(this AuthenticationBuilder builder)
        {
            return builder.AddFreee(options => { });
        }

        public static AuthenticationBuilder AddFreee(this AuthenticationBuilder builder, Action<FreeeAuthenticationOptions> configureOptions)
        {
            return builder.AddFreee(FreeeAuthenticationDefaults.AuthenticationScheme, configureOptions);
        }

        public static AuthenticationBuilder AddFreee(this AuthenticationBuilder builder, string authenticationScheme, Action<FreeeAuthenticationOptions> configureOptions)
        {
            return builder.AddFreee(authenticationScheme, FreeeAuthenticationDefaults.DisplayName, configureOptions);
        }

        public static AuthenticationBuilder AddFreee(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<FreeeAuthenticationOptions> configureOptions)
        {
            return builder.AddOAuth<FreeeAuthenticationOptions, FreeeAuthenticationHandler>(authenticationScheme, displayName, configureOptions);
        }
    }
}
