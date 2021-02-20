using Contract.Architecture.Backend.Core.Persistence.Modules.SessionManagement.Sessions;
using Contract.Architecture.Backend.Core.Persistence.Modules.UserManagement.EmailUserPasswortReset;
using Contract.Architecture.Backend.Core.Persistence.Modules.UserManagement.EmailUsers;
using Microsoft.EntityFrameworkCore;

namespace Contract.Architecture.Backend.Core.Persistence.Tests
{
    public class InMemoryRepositories
    {
        private PersistenceDbContext persistenceDbContext;

        public InMemoryRepositories()
        {
            this.CreatePersistenceDbContext();
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

        private void CreatePersistenceDbContext()
        {
            DbContextOptions<PersistenceDbContext> options;
            var builder = new DbContextOptionsBuilder<PersistenceDbContext>();
            builder.UseInMemoryDatabase("in-memory-db");
            options = builder.Options;

            this.persistenceDbContext = PersistenceDbContext.CustomInstantiate(options);
            this.persistenceDbContext.Database.EnsureDeleted();
            this.persistenceDbContext.Database.EnsureCreated();
        }
    }
}