using Microsoft.Extensions.Options;

namespace Contract.Architecture.Backend.Core.API.Security.Authentication
{
    public class TokenAuthenticationPostConfigureOptions : IPostConfigureOptions<TokenAuthenticationOptions>
    {
        public void PostConfigure(string name, TokenAuthenticationOptions options)
        {
            // if (string.IsNullOrEmpty(options.ExampleConfiguration))
            // {
            //    throw new InvalidOperationException("ExampleConfiguration must be provided in options");
            // }
        }
    }
}