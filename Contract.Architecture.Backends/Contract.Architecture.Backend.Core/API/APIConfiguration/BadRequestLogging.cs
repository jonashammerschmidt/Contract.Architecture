using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.Linq;

namespace Contract.Architecture.Backend.Core.API.APIConfiguration
{
    public static class BadRequestLogging
    {
        public static void Configure(IServiceCollection services)
        {
            services.PostConfigure((Action<ApiBehaviorOptions>)(options =>
            {
                var builtInFactory = options.InvalidModelStateResponseFactory;

                options.InvalidModelStateResponseFactory = context =>
                {
                    string requestMethod = context.HttpContext.Request.Method;
                    string requestPath = context.HttpContext.Request.Path;
                    string modelStateErrorMessage = GetErrorMessageFromModelState(context);

                    LogBadRequestWarning(requestMethod, requestPath, modelStateErrorMessage);

                    return builtInFactory(context);
                };
            }));
        }

        private static string GetErrorMessageFromModelState(ActionContext context)
        {
            var errorMessages = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
            return string.Join(" ", errorMessages);
        }

        private static void LogBadRequestWarning(string requestMethod, string requestPath, string modelStateErrorMessage)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Warn("Fehler bei der Eingabevalidierung in {request-method} {request-path}: " + modelStateErrorMessage, requestMethod, requestPath);
        }
    }
}