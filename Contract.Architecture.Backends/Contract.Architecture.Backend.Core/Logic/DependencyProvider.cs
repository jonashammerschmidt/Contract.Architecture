﻿using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Sessions;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Sessions.Sessions;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Users;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Users.EmailUserPasswordReset;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Email;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Identifier;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Password;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Time;
using Contract.Architecture.Backend.Core.Logic.Modules.Sessions.Sessions;
using Contract.Architecture.Backend.Core.Logic.Modules.Users.EmailUserPasswordReset;
using Contract.Architecture.Backend.Core.Logic.Modules.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Logic.Services.ScheduledJobs;
using Contract.Architecture.Backend.Core.Logic.SystemConnections.Email;
using Contract.Architecture.Backend.Core.Logic.Tools.Identifier;
using Contract.Architecture.Backend.Core.Logic.Tools.Password;
using Contract.Architecture.Backend.Core.Logic.Tools.Time;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contract.Architecture.Backend.Core.Logic
{
    public static class DependencyProvider
    {
        public static void Startup(IServiceCollection services, IConfiguration configuration)
        {
            StartupUsers(services, configuration);
            StartupSessions(services, configuration);
            StartupServices(services, configuration);
        }

        private static void StartupUsers(IServiceCollection services, IConfiguration configuration)
        {
            // EmailUser
            services.AddScoped<IEmailUserLoginLogic, EmailUserLoginLogic>();
            services.AddScoped<IEmailUserPasswordChangeLogic, EmailUserPasswordChangeLogic>();
            services.AddScoped<IEmailUserCrudLogic, EmailUserCrudLogic>();

            // EmailUserPasswordReset
            services.AddScoped<IEmailUserPasswordResetLogic, EmailUserPasswordResetLogic>();
            services.AddScheduledJob<EmailUserPasswordResetExpirationScheduledJob>();
            services.AddOptionsFromConfiguration<EmailUserPasswordResetOptions>(configuration);
        }

        private static void StartupSessions(IServiceCollection services, IConfiguration configuration)
        {
            // Sessions
            services.AddScoped<ISessionsCrudLogic, SessionsCrudLogic>();
            services.AddScheduledJob<SessionExpirationScheduledJob>();
            services.AddOptionsFromConfiguration<SessionExpirationOptions>(configuration);
        }

        private static void StartupServices(IServiceCollection services, IConfiguration configuration)
        {
            // Passwort
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            // DateTime
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            // E-Mail
            services.AddSingleton<IEmailClient, EmailClient>();
            services.AddOptionsFromConfiguration<EmailClientOptions>(configuration);

            // Guid
            services.AddSingleton<IGuidGenerator, GuidGenerator>();

            // SHA256 Token
            services.AddSingleton<ISHA256TokenGenerator, SHA256TokenGenerator>();
        }
    }
}