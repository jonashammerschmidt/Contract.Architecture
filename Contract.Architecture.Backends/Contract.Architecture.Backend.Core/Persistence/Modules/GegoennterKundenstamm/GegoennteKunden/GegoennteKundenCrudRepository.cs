using Contract.Architecture.Backend.Core.Contract.Contexts;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Persistence.Tools.Pagination;
using Contract.Architecture.Backend.Core.Persistence.Tools.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden
{
    internal class GegoennteKundenCrudRepository : IGegoennteKundenCrudRepository
    {
        private readonly IPaginationContext paginationContext;

        private readonly PersistenceDbContext dbContext;

        public GegoennteKundenCrudRepository(
            IPaginationContext paginationContext,
            PersistenceDbContext dbContext)
        {
            this.paginationContext = paginationContext;

            this.dbContext = dbContext;
        }

        public void CreateGegoennterKunde(IDbGegoennterKunde dbGegoennterKunde)
        {
            this.dbContext.GegoennteKunden.Add(DbGegoennterKunde.ToEfGegoennterKunde(dbGegoennterKunde));
            this.dbContext.SaveChanges();
        }

        public void DeleteGegoennterKunde(Guid gegoennterKundeId)
        {
            EfGegoennterKunde efGegoennterKunde = this.dbContext.GegoennteKunden
                .Where(efGegoennterKunde => efGegoennterKunde.Id == gegoennterKundeId)
                .FirstOrDefault();

            this.dbContext.GegoennteKunden.Remove(efGegoennterKunde);
            this.dbContext.SaveChanges();
        }

        public bool DoesGegoennterKundeExist(Guid gegoennterKundeId)
        {
            return this.dbContext.GegoennteKunden.Any(efGegoennterKunde => efGegoennterKunde.Id == gegoennterKundeId);
        }

        public IDbGegoennterKunde GetGegoennterKunde(Guid gegoennterKundeId)
        {
            EfGegoennterKunde efGegoennterKunde = this.dbContext.GegoennteKunden
                .Where(efGegoennterKunde => efGegoennterKunde.Id == gegoennterKundeId)
                .FirstOrDefault();

            return DbGegoennterKunde.FromEfGegoennterKunde(efGegoennterKunde);
        }

        public IDbGegoennterKundeDetail GetGegoennterKundeDetail(Guid gegoennterKundeId)
        {
            EfGegoennterKunde efGegoennterKunde = this.dbContext.GegoennteKunden
                .Include(efGegoennterKunde => efGegoennterKunde.BesteBank)
                .Where(efGegoennterKunde => efGegoennterKunde.Id == gegoennterKundeId)
                .FirstOrDefault();

            return DbGegoennterKundeDetail.FromEfGegoennterKunde(efGegoennterKunde);
        }

        public IDbPagedResult<IDbGegoennterKundeListItem> GetPagedGegoennteKunden()
        {
            var efGegoennteKunden = this.dbContext.GegoennteKunden
                .Include(efKunden => efKunden.BesteBank);

            return Pagination.Filter(
                efGegoennteKunden,
                this.paginationContext,
                efGegoennterKunde => DbGegoennterKundeListItem.FromEfGegoennterKunde(efGegoennterKunde));
        }

        public IEnumerable<IDbGegoennterKunde> GetAllGegoennteKunden()
        {
            return this.dbContext.GegoennteKunden
                .Select(efGegoennterKunde => DbGegoennterKunde.FromEfGegoennterKunde(efGegoennterKunde));
        }

        public void UpdateGegoennterKunde(IDbGegoennterKunde dbGegoennterKunde)
        {
            EfGegoennterKunde efGegoennterKunde = this.dbContext.GegoennteKunden
                .Where(efGegoennterKunde => efGegoennterKunde.Id == dbGegoennterKunde.Id)
                .FirstOrDefault();

            DbGegoennterKunde.UpdateEfGegoennterKunde(efGegoennterKunde, dbGegoennterKunde);

            this.dbContext.GegoennteKunden.Update(efGegoennterKunde);
            this.dbContext.SaveChanges();
        }
    }
}