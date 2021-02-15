using Microsoft.AspNetCore.Mvc;

namespace Contract.Architecture.Backend.Core.API.Security.Authorization
{
    public sealed class AuthorizedAttribute : TypeFilterAttribute
    {
        public AuthorizedAttribute(params string[] permissions)
            : base(typeof(AuthorizedFilter))
        {
            this.Arguments = new object[] { permissions };
        }
    }
}