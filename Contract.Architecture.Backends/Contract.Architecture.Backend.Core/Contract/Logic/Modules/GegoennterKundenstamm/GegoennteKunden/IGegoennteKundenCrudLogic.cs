using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using System;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden
{
    public interface IGegoennteKundenCrudLogic
    {
        ILogicResult<Guid> CreateGegoennterKunde(IGegoennterKundeCreate gegoennterKundeCreate);

        ILogicResult DeleteGegoennterKunde(Guid gegoennterKundeId);

        ILogicResult<IGegoennterKundeDetail> GetGegoennterKundeDetail(Guid gegoennterKundeId);

        ILogicResult<IEnumerable<IGegoennterKunde>> GetGegoennteKunden();

        ILogicResult UpdateGegoennterKunde(IGegoennterKundeUpdate gegoennterKundeUpdate);
    }
}