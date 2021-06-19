using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Pagination;
using System;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken
{
    public interface IGegoennteBankenCrudLogic
    {
        ILogicResult<Guid> CreateGegoennteBank(IGegoennteBankCreate gegoennteBankCreate);

        ILogicResult DeleteGegoennteBank(Guid gegoennteBankId);

        ILogicResult<IGegoennteBankDetail> GetGegoennteBankDetail(Guid gegoennteBankId);

        ILogicResult<IPagedResult<IGegoennteBank>> GetGegoennteBanken();

        ILogicResult UpdateGegoennteBank(IGegoennteBankUpdate gegoennteBankUpdate);
    }
}