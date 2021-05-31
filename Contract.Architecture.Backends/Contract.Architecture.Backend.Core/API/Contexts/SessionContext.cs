using Contract.Architecture.Backend.Core.API.Security;
using Contract.Architecture.Backend.Core.Contract;
using Microsoft.AspNetCore.Http;
using System;

namespace Contract.Architecture.Backend.Core.API.Contexts
{
    public class SessionContext : ISessionContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public SessionContext(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated
        {
            get
            {
                return this.httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
            }
        }

        public Guid EmailUserId
        {
            get
            {
                return this.httpContextAccessor.HttpContext.User.GetEmailUserId();
            }
        }

        public string SessionToken
        {
            get
            {
                return this.httpContextAccessor.HttpContext.User.GetSessionToken();
            }
        }

        public string UserName
        {
            get
            {
                return this.httpContextAccessor.HttpContext.User.GetName();
            }
        }

        public bool HasPermission(string permissionName)
        {
            if (this.httpContextAccessor.HttpContext != null)
            {
                return false;
            }

            return this.httpContextAccessor.HttpContext.User.HasPermission(permissionName);
        }
    }
}