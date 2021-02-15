using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Sessions.Sessions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Contract.Architecture.Backend.Core.API.Security.Authentication
{
    public class TokenAuthenticationHandler : AuthenticationHandler<TokenAuthenticationOptions>
    {
        private readonly ISessionsCrudLogic sessionsLogic;

        public TokenAuthenticationHandler(
            IOptionsMonitor<TokenAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            ISessionsCrudLogic sessionsLogic)
            : base(options, logger, encoder, clock)
        {
            this.sessionsLogic = sessionsLogic;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            // Validate authorization header format
            if (this.IsNoTokenProvided(this.Request.Headers))
            {
                return AuthenticateResult.NoResult();
            }

            var token = this.ExtractSessionToken(this.Request.Headers);
            if (token == null)
            {
                logger.Warn("Format des Authorization-Headers ungültig für {request-method} {request-path}.", this.Request.Method, this.Request.Path);
                return AuthenticateResult.Fail("Format of authorization header invalid");
            }

            ILogicResult<Contract.Logic.Modules.Sessions.Sessions.ISession> validationResult = this.sessionsLogic.GetSessionFromToken(token);
            if (!validationResult.IsSuccessful)
            {
                logger.Warn("Ungültiger oder abgelaufener Session-Token für {request-method} {request-path}.", this.Request.Method, this.Request.Path);
                return AuthenticateResult.Fail("Token invalid");
            }

            Contract.Logic.Modules.Sessions.Sessions.ISession session = validationResult.Data;

            AuthenticationTicket ticket = this.CreateAuthenticationTicketFromValidSession(session);
            return AuthenticateResult.Success(ticket);
        }

        private bool IsNoTokenProvided(IHeaderDictionary headers)
        {
            return !headers["Authorization"].Any();
        }

        private string ExtractSessionToken(IHeaderDictionary headers)
        {
            var authorizationHeaderValue = headers["Authorization"].ToString().Split(" ");

            if (authorizationHeaderValue.Length != 2 || authorizationHeaderValue[0] != "Token")
            {
                return null;
            }

            string token = authorizationHeaderValue[1];
            return token;
        }

        private AuthenticationTicket CreateAuthenticationTicketFromValidSession(Contract.Logic.Modules.Sessions.Sessions.ISession session)
        {
            List<Claim> claims = this.GenerateClaimsFromSession(session);

            ClaimsPrincipal principal = new ClaimsPrincipal();
            principal.AddIdentity(new ClaimsIdentity(claims, TokenAuthentication.Scheme));

            var ticket = new AuthenticationTicket(principal, this.Scheme.Name);
            return ticket;
        }

        private List<Claim> GenerateClaimsFromSession(Contract.Logic.Modules.Sessions.Sessions.ISession session)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, session.Name),
                new Claim(ClaimTypesExtension.EmailUserId, session.EmailUserId.ToString()),
                new Claim(ClaimTypesExtension.Token, session.Token)
            };

            return claims;
        }
    }
}