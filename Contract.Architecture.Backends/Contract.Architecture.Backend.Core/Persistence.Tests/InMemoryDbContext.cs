using Contract.Architecture.Backend.Core.Persistence.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Persistence.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Persistence.Tests.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Persistence.Tests.Modules.Kundenstamm.Kunden;
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

            persistenceDbContext.Banken.Add(DbBank.ToEfBank(DbBankTest.DbDefault()));
            persistenceDbContext.Banken.Add(DbBank.ToEfBank(DbBankTest.DbDefault2()));
            persistenceDbContext.Kunden.Add(DbKunde.ToEfKunde(DbKundeTest.DbDefault()));
            persistenceDbContext.Kunden.Add(DbKunde.ToEfKunde(DbKundeTest.DbDefault2()));
            persistenceDbContext.SaveChanges();

            return persistenceDbContext;
        }
    }
}