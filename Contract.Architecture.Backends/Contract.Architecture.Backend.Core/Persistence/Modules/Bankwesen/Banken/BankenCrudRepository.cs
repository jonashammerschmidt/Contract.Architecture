using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.Bankwesen.Banken
{
    internal class BankenCrudRepository : IBankenCrudRepository
    {
        private readonly PersistenceDbContext dbContext;

        public BankenCrudRepository(PersistenceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateBank(IDbBank dbBank)
        {
            this.dbContext.Banken.Add(DbBank.ToEfBank(dbBank));
            this.dbContext.SaveChanges();
        }

        public void DeleteBank(Guid bankId)
        {
            EfBank efBank = this.dbContext.Banken
                .Where(efBank => efBank.Id == bankId)
                .FirstOrDefault();

            this.dbContext.Banken.Remove(efBank);
            this.dbContext.SaveChanges();
        }

        public bool DoesBankExist(Guid bankId)
        {
            return this.dbContext.Banken.Any(efBank => efBank.Id == bankId);
        }

        public IDbBank GetBank(Guid bankId)
        {
            EfBank efBank = this.dbContext.Banken
                .Where(efBank => efBank.Id == bankId)
                .FirstOrDefault();

            return DbBank.FromEfBank(efBank);
        }

        public IDbBankDetail GetBankDetail(Guid bankId)
        {
            EfBank efBank = this.dbContext.Banken
                .Include(efBank => efBank.Kunden)
                .Where(efBank => efBank.Id == bankId)
                .FirstOrDefault();

            return DbBankDetail.FromEfBank(efBank);
        }

        public IEnumerable<IDbBank> GetBanken()
        {
            return this.dbContext.Banken
                .Select(efBank => DbBank.FromEfBank(efBank));
        }

        public void UpdateBank(IDbBank dbBank)
        {
            EfBank efBank = this.dbContext.Banken
                .Where(efBank => efBank.Id == dbBank.Id)
                .FirstOrDefault();

            DbBank.UpdateEfBank(efBank, dbBank);
            this.dbContext.Banken.Update(efBank);

            this.dbContext.SaveChanges();
        }
    }
}