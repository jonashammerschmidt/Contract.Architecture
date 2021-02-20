using Microsoft.AspNetCore.Http;
using UAParser;

namespace Contract.Architecture.Backend.Core.API.Tools.UserAgent
{
    public static class UserAgentParser
    {
        public static string GetBrowser(HttpRequest request)
        {
            ClientInfo c = GetClientInfoFromRequest(request);
            return c.UA.Family;
        }

        public static string GetOperatingSystem(HttpRequest request)
        {
            ClientInfo c = GetClientInfoFromRequest(request);
            return c.OS.ToString();
        }

        private static ClientInfo GetClientInfoFromRequest(HttpRequest request)
        {
            var emailUserAgent = request.Headers["EmailUser-Agent"].ToString();

            var emailUserAgentParser = Parser.GetDefault();

            ClientInfo c = emailUserAgentParser.Parse(emailUserAgent);
            return c;
        }
    }
}