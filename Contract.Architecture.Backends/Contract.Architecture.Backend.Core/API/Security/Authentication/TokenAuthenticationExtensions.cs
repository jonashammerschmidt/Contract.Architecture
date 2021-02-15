using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Sessions.Sessions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Contract.Architecture.Backend.Core.API.Security.Authentication
{
    public static class TokenAuthenticationExtensions
    {
        public static AuthenticationBuilder AddTokenAuthentication<TAuthService>(this AuthenticationBuilder builder)
            where TAuthService : ISessionsCrudLogic
        {
            return AddTokenAuthentication<TAuthService>(builder, TokenAuthentication.Scheme, _ => { });
        }

        public static AuthenticationBuilder AddTokenAuthentication<TAuthService>(this AuthenticationBuilder builder, string authenticationScheme)
            where TAuthService : ISessionsCrudLogic
        {
            return AddTokenAuthentication<TAuthService>(builder, authenticationScheme, _ => { });
        }

        public static AuthenticationBuilder AddTokenAuthentication<TAuthService>(this AuthenticationBuilder builder, Action<TokenAuthenticationOptions> configureOptions)
            where TAuthService : ISessionsCrudLogic
        {
            return AddTokenAuthentication<TAuthService>(builder, TokenAuthentication.Scheme, configureOptions);
        }

        public static AuthenticationBuilder AddTokenAuthentication<TAuthService>(this AuthenticationBuilder builder, string authenticationScheme, Action<TokenAuthenticationOptions> configureOptions)
            where TAuthService : ISessionsCrudLogic
        {
            builder.Services.AddSingleton<IPostConfigureOptions<TokenAuthenticationOptions>, TokenAuthenticationPostConfigureOptions>();

            return builder.AddScheme<TokenAuthenticationOptions, TokenAuthenticationHandler>(
                authenticationScheme, configureOptions);
        }
    }
}