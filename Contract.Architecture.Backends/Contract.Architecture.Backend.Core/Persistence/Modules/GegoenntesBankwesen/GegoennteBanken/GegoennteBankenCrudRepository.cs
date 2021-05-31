using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken
{
    internal class GegoennteBankenCrudRepository : IGegoennteBankenCrudRepository
    {
        private readonly PersistenceDbContext dbContext;

        public GegoennteBankenCrudRepository(PersistenceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateGegoennteBank(IDbGegoennteBank dbGegoennteBank)
        {
            this.dbContext.GegoennteBanken.Add(DbGegoennteBank.ToEfGegoennteBank(dbGegoennteBank));
            this.dbContext.SaveChanges();
        }

        public void DeleteGegoennteBank(Guid gegoennteBankId)
        {
            EfGegoennteBank efGegoennteBank = this.dbContext.GegoennteBanken
                .Where(efGegoennteBank => efGegoennteBank.Id == gegoennteBankId)
                .FirstOrDefault();

            this.dbContext.GegoennteBanken.Remove(efGegoennteBank);
            this.dbContext.SaveChanges();
        }

        public bool DoesGegoennteBankExist(Guid gegoennteBankId)
        {
            return this.dbContext.GegoennteBanken.Any(efGegoennteBank => efGegoennteBank.Id == gegoennteBankId);
        }

        public IDbGegoennteBank GetGegoennteBank(Guid gegoennteBankId)
        {
            EfGegoennteBank efGegoennteBank = this.dbContext.GegoennteBanken
                .Where(efGegoennteBank => efGegoennteBank.Id == gegoennteBankId)
                .FirstOrDefault();

            return DbGegoennteBank.FromEfGegoennteBank(efGegoennteBank);
        }

        public IDbGegoennteBankDetail GetGegoennteBankDetail(Guid gegoennteBankId)
        {
            EfGegoennteBank efGegoennteBank = this.dbContext.GegoennteBanken
                .Include(efGegoennteBank => efGegoennteBank.BesteKunden)
                .Where(efGegoennteBank => efGegoennteBank.Id == gegoennteBankId)
                .FirstOrDefault();

            return DbGegoennteBankDetail.FromEfGegoennteBank(efGegoennteBank);
        }

        public IEnumerable<IDbGegoennteBank> GetGegoennteBanken()
        {
            return this.dbContext.GegoennteBanken
                .Select(efGegoennteBank => DbGegoennteBank.FromEfGegoennteBank(efGegoennteBank));
        }

        public void UpdateGegoennteBank(IDbGegoennteBank dbGegoennteBank)
        {
            EfGegoennteBank efGegoennteBank = this.dbContext.GegoennteBanken
                .Where(efGegoennteBank => efGegoennteBank.Id == dbGegoennteBank.Id)
                .FirstOrDefault();

            DbGegoennteBank.UpdateEfGegoennteBank(efGegoennteBank, dbGegoennteBank);

            this.dbContext.GegoennteBanken.Update(efGegoennteBank);
            this.dbContext.SaveChanges();
        }
    }
}