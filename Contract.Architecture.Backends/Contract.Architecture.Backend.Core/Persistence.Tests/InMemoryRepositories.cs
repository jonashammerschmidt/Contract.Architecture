using Contract.Architecture.Backend.Core.Persistence.Modules.SessionManagement.Sessions;
using Contract.Architecture.Backend.Core.Persistence.Modules.UserManagement.EmailUserPasswortReset;
using Contract.Architecture.Backend.Core.Persistence.Modules.UserManagement.EmailUsers;

namespace Contract.Architecture.Backend.Core.Persistence.Tests
{
    public class InMemoryRepositories
    {
        private PersistenceDbContext persistenceDbContext;

        public InMemoryRepositories()
        {
            this.persistenceDbContext = InMemoryDbContext.CreatePersistenceDbContextEmpty();
        }

        internal EmailUsersRepository GetEmailUsersRepository()
        {
            return new EmailUsersRepository(this.persistenceDbContext);
        }

        internal EmailUserPasswortResetTokensRepository GetEmailUserPasswordResetTokenRepository()
        {
            return new EmailUserPasswortResetTokensRepository(this.persistenceDbContext);
        }

        internal SessionsRepository GetSessionsRepository()
        {
            return new SessionsRepository(this.persistenceDbContext);
        }
    }
}