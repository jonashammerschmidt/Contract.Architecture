using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Pagination;
using System;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden
{
    public interface IGegoennteKundenCrudLogic
    {
        ILogicResult<Guid> CreateGegoennterKunde(IGegoennterKundeCreate gegoennterKundeCreate);

        ILogicResult DeleteGegoennterKunde(Guid gegoennterKundeId);

        ILogicResult<IGegoennterKundeDetail> GetGegoennterKundeDetail(Guid gegoennterKundeId);

        ILogicResult<IPagedResult<IGegoennterKunde>> GetGegoennteKunden();

        ILogicResult UpdateGegoennterKunde(IGegoennterKundeUpdate gegoennterKundeUpdate);
    }
}