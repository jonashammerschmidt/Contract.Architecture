using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.SessionManagement.Sessions;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.UserManagement.EmailUserPasswortResetTokens;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.UserManagement.EmailUsers;
using Contract.Architecture.Backend.Core.Persistence;
using Contract.Architecture.Backend.Core.Persistence.Modules.SessionManagement.Sessions;
using Contract.Architecture.Backend.Core.Persistence.Modules.UserManagement.EmailUserPasswortReset;
using Contract.Architecture.Backend.Core.Persistence.Modules.UserManagement.EmailUsers;
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