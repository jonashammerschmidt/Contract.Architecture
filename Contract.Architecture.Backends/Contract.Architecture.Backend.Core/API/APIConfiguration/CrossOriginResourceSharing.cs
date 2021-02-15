using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contract.Architecture.Backend.Core.API.APIConfiguration
{
    public static class CrossOriginResourceSharing
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(cors =>
                cors.AddDefaultPolicy(policy =>
                    policy.WithOrigins(configuration["CorsOrigins"]).AllowAnyHeader().AllowAnyMethod()));
        }
    }
}