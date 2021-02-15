using Contract.Architecture.Backend.Core.Contract.Persistence.Model.Sessions.Sessions;
using Contract.Architecture.Backend.Core.Contract.Persistence.Model.Users.EmailUserPasswortReset;
using Contract.Architecture.Backend.Core.Contract.Persistence.Model.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Persistence.Model;
using Contract.Architecture.Backend.Core.Persistence.Model.Sessions.Sessions;
using Contract.Architecture.Backend.Core.Persistence.Model.Users.EmailUserPasswortReset;
using Contract.Architecture.Backend.Core.Persistence.Model.Users.EmailUsers;
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