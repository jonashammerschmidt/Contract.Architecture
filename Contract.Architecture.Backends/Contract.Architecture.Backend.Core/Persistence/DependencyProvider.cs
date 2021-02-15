using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Sessions.Sessions;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Users.EmailUserPasswortReset;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Persistence;
using Contract.Architecture.Backend.Core.Persistence.Modules.Sessions.Sessions;
using Contract.Architecture.Backend.Core.Persistence.Modules.Users.EmailUserPasswortReset;
using Contract.Architecture.Backend.Core.Persistence.Modules.Users.EmailUsers;
using Microsoft.Extensions.DependencyInjection;

namespace Contract.Architecture.Backend.Core.Persistence
{
    public static class DependencyProvider
    {
        public static void Startup(IServiceCollection services)
        {
            services.AddDbContext<PersistenceDbContext>();

            StartupUsers(services);
            StartupSessions(services);
        }

        private static void StartupUsers(IServiceCollection services)
        {
            services.AddScoped<IEmailUsersRepository, EmailUsersRepository>();
            services.AddScoped<IEmailUserPasswortResetTokensRepository, EmailUserPasswortResetTokensRepository>();
        }

        private static void StartupSessions(IServiceCollection services)
        {
            services.AddScoped<ISessionsRepository, SessionsRepository>();
        }
    }
}