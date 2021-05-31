using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using System;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken
{
    public interface IGegoennteBankenCrudLogic
    {
        ILogicResult<Guid> CreateGegoennteBank(IGegoennteBankCreate gegoennteBankCreate);

        ILogicResult DeleteGegoennteBank(Guid gegoennteBankId);

        ILogicResult<IGegoennteBankDetail> GetGegoennteBankDetail(Guid gegoennteBankId);

        ILogicResult<IEnumerable<IGegoennteBank>> GetGegoennteBanken();

        ILogicResult UpdateGegoennteBank(IGegoennteBankUpdate gegoennteBankUpdate);
    }
}