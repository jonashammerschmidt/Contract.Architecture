using System;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Kundenstamm.Kunden
{
    public interface IKundenCrudRepository
    {
        void CreateKunde(IDbKunde kunde);

        void DeleteKunde(Guid kundeId);

        bool DoesKundeExist(Guid kundeId);

        IDbKunde GetKunde(Guid kundeId);

        IDbKundeDetail GetKundeDetail(Guid kundeId);

        IEnumerable<IDbKunde> GetKunden();

        void UpdateKunde(IDbKunde kunde);
    }
}