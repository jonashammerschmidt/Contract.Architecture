using System;
using System.Linq;
using System.Security.Claims;

namespace Contract.Architecture.Backend.Core.API.Security
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetEmailUserId(this ClaimsPrincipal principal)
        {
            return Guid.Parse(principal.FindFirstValue(ClaimTypesExtension.EmailUserId));
        }

        public static string GetSessionToken(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypesExtension.Token);
        }

        public static string GetName(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Name);
        }

        public static bool HasPermission(this ClaimsPrincipal principal, string permissionName)
        {
            return principal.FindAll(ClaimTypesExtension.Permissions)
                .Select(claim => claim.Value)
                .Contains(permissionName);
        }
    }
}