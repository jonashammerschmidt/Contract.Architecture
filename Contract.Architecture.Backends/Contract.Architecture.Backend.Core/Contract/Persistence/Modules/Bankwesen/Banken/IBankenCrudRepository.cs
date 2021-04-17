using System;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken
{
    public interface IBankenCrudRepository
    {
        void CreateBank(IDbBank bank);

        void DeleteBank(Guid bankId);

        bool DoesBankExist(Guid bankId);

        IDbBank GetBank(Guid bankId);

        IDbBankDetail GetBankDetail(Guid bankId);

        IEnumerable<IDbBank> GetBanken();

        void UpdateBank(IDbBank bank);
    }
}