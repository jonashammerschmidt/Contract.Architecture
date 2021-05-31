using Contract.Architecture.Backend.Core.Contract.Contexts;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Contract.Architecture.Backend.Core.API.Middlewares
{
    public class PaginationExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public PaginationExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (PaginationException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new
                {
                    type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    title = "One or more validation errors occurred.",
                    status = 400,
                    traceId = Activity.Current?.Id ?? context?.TraceIdentifier,
                    errors = new
                    {
                        pagination = new[] { "The format of the filter, sort or pagination is not valid." }
                    }
                });
            }
        }
    }
}