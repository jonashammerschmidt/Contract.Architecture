using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Identifier;
using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Pagination;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Tools.Pagination;
using Contract.Architecture.Backend.Core.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Logic.Tools.Pagination;
using Microsoft.Extensions.Logging;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Modules.GegoenntesBankwesen.GegoennteBanken
{
    internal class GegoennteBankenCrudLogic : IGegoennteBankenCrudLogic
    {
        private readonly IGegoennteBankenCrudRepository gegoennteBankenCrudRepository;

        private readonly IGuidGenerator guidGenerator;
        private readonly ILogger<GegoennteBankenCrudLogic> logger;

        public GegoennteBankenCrudLogic(
            IGegoennteBankenCrudRepository gegoennteBankenCrudRepository,
            IGuidGenerator guidGenerator,
            ILogger<GegoennteBankenCrudLogic> logger)
        {
            this.gegoennteBankenCrudRepository = gegoennteBankenCrudRepository;

            this.guidGenerator = guidGenerator;
            this.logger = logger;
        }

        public ILogicResult<Guid> CreateGegoennteBank(IGegoennteBankCreate gegoennteBankCreate)
        {
            Guid newGegoennteBankId = this.guidGenerator.NewGuid();
            IDbGegoennteBank dbGegoennteBankToCreate = GegoennteBank.CreateDbGegoennteBank(newGegoennteBankId, gegoennteBankCreate);
            this.gegoennteBankenCrudRepository.CreateGegoennteBank(dbGegoennteBankToCreate);

            this.logger.LogInformation($"GegoennteBank ({newGegoennteBankId}) angelegt");
            return LogicResult<Guid>.Ok(newGegoennteBankId);
        }

        public ILogicResult DeleteGegoennteBank(Guid gegoennteBankId)
        {
            if (!this.gegoennteBankenCrudRepository.DoesGegoennteBankExist(gegoennteBankId))
            {
                this.logger.LogDebug($"GegoennteBank ({gegoennteBankId}) konnte nicht gefunden werden.");
                return LogicResult.NotFound($"GegoennteBank ({gegoennteBankId}) konnte nicht gefunden werden.");
            }

            // TODO: If relations are implemented, resolve conflict with the FOREIGN KEY constraint
            try
            {
                this.gegoennteBankenCrudRepository.DeleteGegoennteBank(gegoennteBankId);
            }
            catch
            {
                this.logger.LogDebug($"GegoennteBank ({gegoennteBankId}) konnte nicht gelöscht werden.");
                return LogicResult.Conflict($"GegoennteBank ({gegoennteBankId}) konnte nicht gelöscht werden.");
            }

            this.logger.LogInformation($"GegoennteBank ({gegoennteBankId}) gelöscht");
            return LogicResult.Ok();
        }

        public ILogicResult<IGegoennteBankDetail> GetGegoennteBankDetail(Guid gegoennteBankId)
        {
            IDbGegoennteBankDetail dbGegoennteBankDetail = this.gegoennteBankenCrudRepository.GetGegoennteBankDetail(gegoennteBankId);
            if (dbGegoennteBankDetail == null)
            {
                this.logger.LogDebug($"GegoennteBank ({gegoennteBankId}) konnte nicht gefunden werden.");
                return LogicResult<IGegoennteBankDetail>.NotFound($"GegoennteBank ({gegoennteBankId}) konnte nicht gefunden werden.");
            }

            this.logger.LogDebug($"Details für GegoennteBank ({gegoennteBankId}) wurde geladen");
            return LogicResult<IGegoennteBankDetail>.Ok(GegoennteBankDetail.FromDbGegoennteBankDetail(dbGegoennteBankDetail));
        }

        public ILogicResult<IPagedResult<IGegoennteBank>> GetGegoennteBanken()
        {
            IDbPagedResult<IDbGegoennteBank> dbGegoennteBankenPagedResult =
                this.gegoennteBankenCrudRepository.GetGegoennteBanken();

            IPagedResult<IGegoennteBank> gegoennteBankenPagedResult =
                PagedResult.FromDbPagedResult(
                    dbGegoennteBankenPagedResult,
                    (dbGegoennteBanken) => GegoennteBank.FromDbGegoennteBank(dbGegoennteBanken));

            this.logger.LogDebug("GegoennteBanken wurden geladen");
            return LogicResult<IPagedResult<IGegoennteBank>>.Ok(gegoennteBankenPagedResult);
        }

        public ILogicResult UpdateGegoennteBank(IGegoennteBankUpdate gegoennteBankUpdate)
        {
            IDbGegoennteBank dbGegoennteBankToUpdate = this.gegoennteBankenCrudRepository.GetGegoennteBank(gegoennteBankUpdate.Id);
            if (dbGegoennteBankToUpdate == null)
            {
                this.logger.LogDebug($"GegoennteBank ({gegoennteBankUpdate.Id}) konnte nicht gefunden werden.");
                return LogicResult.NotFound($"GegoennteBank ({gegoennteBankUpdate.Id}) konnte nicht gefunden werden.");
            }

            GegoennteBank.UpdateDbGegoennteBank(dbGegoennteBankToUpdate, gegoennteBankUpdate);

            this.gegoennteBankenCrudRepository.UpdateGegoennteBank(dbGegoennteBankToUpdate);

            this.logger.LogInformation($"GegoennteBank ({gegoennteBankUpdate.Id}) aktualisiert");
            return LogicResult.Ok();
        }
    }
}