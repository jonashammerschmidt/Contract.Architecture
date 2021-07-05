using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Identifier;
using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Pagination;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Tools.Pagination;
using Contract.Architecture.Backend.Core.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Logic.Tools.Pagination;
using Microsoft.Extensions.Logging;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Modules.GegoennterKundenstamm.GegoennteKunden
{
    internal class GegoennteKundenCrudLogic : IGegoennteKundenCrudLogic
    {
        private readonly IGegoennteKundenCrudRepository gegoennteKundenCrudRepository;
        private readonly IGegoennteBankenCrudRepository gegoennteBankenCrudRepository;

        private readonly IGuidGenerator guidGenerator;
        private readonly ILogger<GegoennteKundenCrudLogic> logger;

        public GegoennteKundenCrudLogic(
            IGegoennteKundenCrudRepository gegoennteKundenCrudRepository,
            IGegoennteBankenCrudRepository gegoennteBankenCrudRepository,
            IGuidGenerator guidGenerator,
            ILogger<GegoennteKundenCrudLogic> logger)
        {
            this.gegoennteKundenCrudRepository = gegoennteKundenCrudRepository;
            this.gegoennteBankenCrudRepository = gegoennteBankenCrudRepository;

            this.guidGenerator = guidGenerator;
            this.logger = logger;
        }

        public ILogicResult<Guid> CreateGegoennterKunde(IGegoennterKundeCreate gegoennterKundeCreate)
        {
            if (!this.gegoennteBankenCrudRepository.DoesGegoennteBankExist(gegoennterKundeCreate.BesteBankId))
            {
                this.logger.LogDebug("BesteBank konnte nicht gefunden werden.");
                return LogicResult<Guid>.NotFound("BesteBank konnte nicht gefunden werden.");
            }

            Guid newGegoennterKundeId = this.guidGenerator.NewGuid();
            IDbGegoennterKunde dbGegoennterKundeToCreate = GegoennterKunde.CreateDbGegoennterKunde(newGegoennterKundeId, gegoennterKundeCreate);
            this.gegoennteKundenCrudRepository.CreateGegoennterKunde(dbGegoennterKundeToCreate);

            this.logger.LogInformation($"GegoennterKunde ({newGegoennterKundeId}) angelegt");
            return LogicResult<Guid>.Ok(newGegoennterKundeId);
        }

        public ILogicResult DeleteGegoennterKunde(Guid gegoennterKundeId)
        {
            if (!this.gegoennteKundenCrudRepository.DoesGegoennterKundeExist(gegoennterKundeId))
            {
                this.logger.LogDebug($"GegoennterKunde ({gegoennterKundeId}) konnte nicht gefunden werden.");
                return LogicResult.NotFound($"GegoennterKunde ({gegoennterKundeId}) konnte nicht gefunden werden.");
            }

            // TODO: If relations are implemented, resolve conflict with the FOREIGN KEY constraint
            try
            {
                this.gegoennteKundenCrudRepository.DeleteGegoennterKunde(gegoennterKundeId);
            }
            catch
            {
                this.logger.LogDebug($"GegoennterKunde ({gegoennterKundeId}) konnte nicht gelöscht werden.");
                return LogicResult.Conflict($"GegoennterKunde ({gegoennterKundeId}) konnte nicht gelöscht werden.");
            }

            this.logger.LogInformation($"GegoennterKunde ({gegoennterKundeId}) gelöscht");
            return LogicResult.Ok();
        }

        public ILogicResult<IGegoennterKundeDetail> GetGegoennterKundeDetail(Guid gegoennterKundeId)
        {
            IDbGegoennterKundeDetail dbGegoennterKundeDetail = this.gegoennteKundenCrudRepository.GetGegoennterKundeDetail(gegoennterKundeId);
            if (dbGegoennterKundeDetail == null)
            {
                this.logger.LogDebug($"GegoennterKunde ({gegoennterKundeId}) konnte nicht gefunden werden.");
                return LogicResult<IGegoennterKundeDetail>.NotFound($"GegoennterKunde ({gegoennterKundeId}) konnte nicht gefunden werden.");
            }

            this.logger.LogDebug($"Details für GegoennterKunde ({gegoennterKundeId}) wurde geladen");
            return LogicResult<IGegoennterKundeDetail>.Ok(GegoennterKundeDetail.FromDbGegoennterKundeDetail(dbGegoennterKundeDetail));
        }

        public ILogicResult<IPagedResult<IGegoennterKundeListItem>> GetPagedGegoennteKunden()
        {
            IDbPagedResult<IDbGegoennterKundeListItem> dbGegoennteKundenListItemPagedResult =
                this.gegoennteKundenCrudRepository.GetPagedGegoennteKunden();

            IPagedResult<IGegoennterKundeListItem> gegoennteKundenListItemPagedResult =
                PagedResult.FromDbPagedResult(
                    dbGegoennteKundenListItemPagedResult,
                    (dbGegoennterKundeListItem) => GegoennterKundeListItem
                        .FromDbGegoennterKundeListItem(dbGegoennterKundeListItem));

            this.logger.LogDebug("GegoennteKunden wurden geladen");
            return LogicResult<IPagedResult<IGegoennterKundeListItem>>.Ok(gegoennteKundenListItemPagedResult);
        }

        public ILogicResult UpdateGegoennterKunde(IGegoennterKundeUpdate gegoennterKundeUpdate)
        {
            if (!this.gegoennteBankenCrudRepository.DoesGegoennteBankExist(gegoennterKundeUpdate.BesteBankId))
            {
                this.logger.LogDebug("BesteBank konnte nicht gefunden werden.");
                return LogicResult.NotFound("BesteBank konnte nicht gefunden werden.");
            }

            IDbGegoennterKunde dbGegoennterKundeToUpdate = this.gegoennteKundenCrudRepository.GetGegoennterKunde(gegoennterKundeUpdate.Id);
            if (dbGegoennterKundeToUpdate == null)
            {
                this.logger.LogDebug($"GegoennterKunde ({gegoennterKundeUpdate.Id}) konnte nicht gefunden werden.");
                return LogicResult.NotFound($"GegoennterKunde ({gegoennterKundeUpdate.Id}) konnte nicht gefunden werden.");
            }

            GegoennterKunde.UpdateDbGegoennterKunde(dbGegoennterKundeToUpdate, gegoennterKundeUpdate);

            this.gegoennteKundenCrudRepository.UpdateGegoennterKunde(dbGegoennterKundeToUpdate);

            this.logger.LogInformation($"GegoennterKunde ({gegoennterKundeUpdate.Id}) aktualisiert");
            return LogicResult.Ok();
        }
    }
}