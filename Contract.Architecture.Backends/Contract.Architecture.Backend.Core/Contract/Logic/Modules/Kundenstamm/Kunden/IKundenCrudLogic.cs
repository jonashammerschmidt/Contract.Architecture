using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using System;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.Kundenstamm.Kunden
{
    public interface IKundenCrudLogic
    {
        ILogicResult<Guid> CreateKunde(IKundeCreate kundeCreate);

        ILogicResult DeleteKunde(Guid kundeId);

        ILogicResult<IKundeDetail> GetKundeDetail(Guid kundeId);

        ILogicResult<IEnumerable<IKunde>> GetKunden();

        ILogicResult UpdateKunde(IKundeUpdate kundeUpdate);
    }
}