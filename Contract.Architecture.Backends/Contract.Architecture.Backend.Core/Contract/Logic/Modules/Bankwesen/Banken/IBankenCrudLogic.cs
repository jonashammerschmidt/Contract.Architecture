using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using System;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.Bankwesen.Banken
{
    public interface IBankenCrudLogic
    {
        ILogicResult<Guid> CreateBank(IBankCreate bankCreate);

        ILogicResult DeleteBank(Guid bankId);

        ILogicResult<IBankDetail> GetBankDetail(Guid bankId);

        ILogicResult<IEnumerable<IBank>> GetBanken();

        ILogicResult UpdateBank(IBankUpdate bankUpdate);
    }
}