using Contract.Architecture.Backend.Core.API.APIConfiguration;
using Contract.Architecture.Backend.Core.API.Contexts;
using Contract.Architecture.Backend.Core.API.Middlewares;
using Contract.Architecture.Backend.Core.API.Security.Authentication;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Sessions;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Sessions.Sessions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Contract.Architecture.Backend.Core.API
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Logic.DependencyProvider.Startup(services, this.configuration);
            Persistence.DependencyProvider.Startup(services);

            SessionContext.Configure(services);

            BadRequestLogging.Configure(services);

            CrossOriginResourceSharing.Configure(services, this.configuration);

            services.AddAuthentication(TokenAuthentication.Scheme).AddTokenAuthentication<ISessionsCrudLogic>();

            services.AddControllers();

            SwaggerSetup.ConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            SwaggerSetup.Configure(app);

            app.UseRouting();
            app.UseCors();
            app.UseMiddleware<ExceptionLoggingMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}