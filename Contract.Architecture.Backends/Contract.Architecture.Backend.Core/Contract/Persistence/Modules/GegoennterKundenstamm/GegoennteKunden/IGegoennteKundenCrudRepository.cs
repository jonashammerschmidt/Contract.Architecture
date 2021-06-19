using Contract.Architecture.Backend.Core.Contract.Persistence.Tools.Pagination;
using System;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden
{
    public interface IGegoennteKundenCrudRepository
    {
        void CreateGegoennterKunde(IDbGegoennterKunde gegoennterKunde);

        void DeleteGegoennterKunde(Guid gegoennterKundeId);

        bool DoesGegoennterKundeExist(Guid gegoennterKundeId);

        IDbGegoennterKunde GetGegoennterKunde(Guid gegoennterKundeId);

        IDbGegoennterKundeDetail GetGegoennterKundeDetail(Guid gegoennterKundeId);

        IDbPagedResult<IDbGegoennterKunde> GetGegoennteKunden();

        IEnumerable<IDbGegoennterKunde> GetAllGegoennteKunden();

        void UpdateGegoennterKunde(IDbGegoennterKunde gegoennterKunde);
    }
}