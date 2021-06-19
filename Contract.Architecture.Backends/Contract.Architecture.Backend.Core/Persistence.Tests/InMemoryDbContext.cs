using Contract.Architecture.Backend.Core.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoenntesBankwesen.GegoennteBanken;
using Microsoft.EntityFrameworkCore;

namespace Contract.Architecture.Backend.Core.Persistence.Tests
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

            persistenceDbContext.GegoennteBanken.Add(DbGegoennteBank.ToEfGegoennteBank(DbGegoennteBankTest.DbDefault()));
            persistenceDbContext.GegoennteBanken.Add(DbGegoennteBank.ToEfGegoennteBank(DbGegoennteBankTest.DbDefault2()));

            persistenceDbContext.GegoennteKunden.Add(DbGegoennterKunde.ToEfGegoennterKunde(DbGegoennterKundeTest.DbDefault()));
            persistenceDbContext.GegoennteKunden.Add(DbGegoennterKunde.ToEfGegoennterKunde(DbGegoennterKundeTest.DbDefault2()));

            persistenceDbContext.SaveChanges();

            return persistenceDbContext;
        }
    }
}