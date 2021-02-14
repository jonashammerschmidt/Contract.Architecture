using Contract.Architecture.Persistence.Model;
using Microsoft.EntityFrameworkCore;

namespace Contract.Architecture.Persistence.Tests
{
    public static class InMemoryDbContext
    {
        public static PersistenceDbContext CreatePersistenceDbContext()
        {
            DbContextOptions<PersistenceDbContext> options;
            var builder = new DbContextOptionsBuilder<PersistenceDbContext>();
            builder.UseInMemoryDatabase("in-memory-db");
            options = builder.Options;

            PersistenceDbContext persistenceDbContext = PersistenceDbContext.CustomInstantiate(options);
            persistenceDbContext.Database.EnsureDeleted();
            persistenceDbContext.Database.EnsureCreated();

            return persistenceDbContext;
        }

        public static PersistenceDbContext CreatePersistenceDbContextWithDefault()
        {
            PersistenceDbContext persistenceDbContext = CreatePersistenceDbContext();

            persistenceDbContext.SaveChanges();

            return persistenceDbContext;
        }
    }
}