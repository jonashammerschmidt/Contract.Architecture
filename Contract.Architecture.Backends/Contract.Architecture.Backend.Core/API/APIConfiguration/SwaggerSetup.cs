using Contract.Architecture.Backend.Core.API.Security.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.API.APIConfiguration
{
    public static class SwaggerSetup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ContractArchitecture - Swagger API Dokumentation",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Token", new OpenApiSecurityScheme
                {
                    Description = @"Token-based Authentication.<br>
                      Enter 'Token' [space] and then your token in the text input below.<br>
                      Example: 'Authentication: Token 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = TokenAuthentication.Scheme
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Token"
                            },
                            Scheme = TokenAuthentication.Scheme,
                            Name = "Token",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}