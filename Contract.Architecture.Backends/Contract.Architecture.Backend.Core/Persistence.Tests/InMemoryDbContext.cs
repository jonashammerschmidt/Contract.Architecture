using Microsoft.EntityFrameworkCore;

namespace Contract.Architecture.Backend.Core.Persistence.Tests
{
    public static class InMemoryDbContext
    {
        public static PersistenceDbContext CreatePersistenceDbContextEmpty()
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

        public static PersistenceDbContext CreatePersistenceDbContextWithDbDefault()
        {
            PersistenceDbContext persistenceDbContext = CreatePersistenceDbContextEmpty();

            persistenceDbContext.SaveChanges();

            return persistenceDbContext;
        }
    }
}