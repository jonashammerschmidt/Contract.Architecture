using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Contract.Architecture.Backend.Core.API.Security.Authorization
{
    public class AuthorizedFilter : IAuthorizationFilter
    {
        private readonly string[] permissions;

        public AuthorizedFilter(params string[] permissions)
        {
            this.permissions = permissions;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (EndpointHasAllowAnonymousFilter(context))
            {
                return;
            }

            if (!this.IsAuthenticated(context) || !this.ContainsRequiredRole(context))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }

        private static bool EndpointHasAllowAnonymousFilter(AuthorizationFilterContext context)
        {
            return context.Filters.Any(item => item is IAllowAnonymousFilter);
        }

        private bool IsAuthenticated(AuthorizationFilterContext context)
        {
            return context.HttpContext.User.Identity.IsAuthenticated;
        }

        private bool ContainsRequiredRole(AuthorizationFilterContext context)
        {
            return this.permissions.Length == 0 ||
                this.permissions.Any(role => context.HttpContext.User.HasClaim(ClaimTypesExtension.Permissions, role));
        }
    }
}