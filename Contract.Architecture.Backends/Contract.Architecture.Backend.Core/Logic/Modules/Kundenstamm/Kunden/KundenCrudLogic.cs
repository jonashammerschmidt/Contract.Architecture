using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Identifier;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Logic.LogicResults;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Logic.Modules.Kundenstamm.Kunden
{
    internal class KundenCrudLogic : IKundenCrudLogic
    {
        private readonly IKundenCrudRepository kundenCrudRepository;
        private readonly IBankenCrudRepository bankenCrudRepository;

        private readonly IGuidGenerator guidGenerator;
        private readonly ILogger<KundenCrudLogic> logger;

        public KundenCrudLogic(
            IKundenCrudRepository kundenCrudRepository,
            IBankenCrudRepository bankenCrudRepository,
            IGuidGenerator guidGenerator,
            ILogger<KundenCrudLogic> logger)
        {
            this.kundenCrudRepository = kundenCrudRepository;
            this.bankenCrudRepository = bankenCrudRepository;

            this.guidGenerator = guidGenerator;
            this.logger = logger;
        }

        public ILogicResult<Guid> CreateKunde(IKundeCreate kundeCreate)
        {
            if (!this.bankenCrudRepository.DoesBankExist(kundeCreate.BankId))
            {
                this.logger.LogDebug("Bank konnte nicht gefunden werden.");
                return LogicResult<Guid>.NotFound("Bank konnte nicht gefunden werden.");
            }

            Guid newKundeId = this.guidGenerator.NewGuid();
            IDbKunde dbKundeToCreate = Kunde.CreateDbKunde(newKundeId, kundeCreate);
            this.kundenCrudRepository.CreateKunde(dbKundeToCreate);

            this.logger.LogInformation($"Kunde ({newKundeId}) angelegt");
            return LogicResult<Guid>.Ok(newKundeId);
        }

        public ILogicResult DeleteKunde(Guid kundeId)
        {
            if (!this.kundenCrudRepository.DoesKundeExist(kundeId))
            {
                this.logger.LogDebug($"Kunde ({kundeId}) konnte nicht gefunden werden.");
                return LogicResult.NotFound($"Kunde ({kundeId}) konnte nicht gefunden werden.");
            }

            // TODO: If relations are implemented, resolve conflict with the FOREIGN KEY constraint
            try
            {
                this.kundenCrudRepository.DeleteKunde(kundeId);
            }
            catch
            {
                this.logger.LogDebug($"Kunde ({kundeId}) konnte nicht gelöscht werden.");
                return LogicResult.Conflict($"Kunde ({kundeId}) konnte nicht gelöscht werden.");
            }

            this.logger.LogInformation($"Kunde ({kundeId}) gelöscht");
            return LogicResult.Ok();
        }

        public ILogicResult<IKundeDetail> GetKundeDetail(Guid kundeId)
        {
            IDbKundeDetail dbKundeDetail = this.kundenCrudRepository.GetKundeDetail(kundeId);
            if (dbKundeDetail == null)
            {
                this.logger.LogDebug($"Kunde ({kundeId}) konnte nicht gefunden werden.");
                return LogicResult<IKundeDetail>.NotFound($"Kunde ({kundeId}) konnte nicht gefunden werden.");
            }

            this.logger.LogDebug($"Details für Kunde ({kundeId}) wurde geladen");
            return LogicResult<IKundeDetail>.Ok(KundeDetail.FromDbKundeDetail(dbKundeDetail));
        }

        public ILogicResult<IEnumerable<IKunde>> GetKunden()
        {
            IEnumerable<IKunde> kunden = this.kundenCrudRepository.GetKunden()
                .Select(kunde => Kunde.FromDbKunde(kunde));

            this.logger.LogDebug("Kunden wurden geladen");
            return LogicResult<IEnumerable<IKunde>>.Ok(kunden);
        }

        public ILogicResult UpdateKunde(IKundeUpdate kundeUpdate)
        {
            if (!this.bankenCrudRepository.DoesBankExist(kundeUpdate.BankId))
            {
                this.logger.LogDebug("Bank konnte nicht gefunden werden.");
                return LogicResult.NotFound("Bank konnte nicht gefunden werden.");
            }

            IDbKunde dbKundeToUpdate = this.kundenCrudRepository.GetKunde(kundeUpdate.Id);
            if (dbKundeToUpdate == null)
            {
                this.logger.LogDebug($"Kunde ({kundeUpdate.Id}) konnte nicht gefunden werden.");
                return LogicResult.NotFound($"Kunde ({kundeUpdate.Id}) konnte nicht gefunden werden.");
            }

            Kunde.UpdateDbKunde(dbKundeToUpdate, kundeUpdate);

            this.kundenCrudRepository.UpdateKunde(dbKundeToUpdate);

            this.logger.LogInformation($"Kunde ({kundeUpdate.Id}) aktualisiert");
            return LogicResult.Ok();
        }
    }
}