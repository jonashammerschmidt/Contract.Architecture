using Contract.Architecture.Backend.Core.Contract.Persistence.Tools.Pagination;
using System;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken
{
    public interface IGegoennteBankenCrudRepository
    {
        void CreateGegoennteBank(IDbGegoennteBank gegoennteBank);

        void DeleteGegoennteBank(Guid gegoennteBankId);

        bool DoesGegoennteBankExist(Guid gegoennteBankId);

        IDbGegoennteBank GetGegoennteBank(Guid gegoennteBankId);

        IDbGegoennteBankDetail GetGegoennteBankDetail(Guid gegoennteBankId);

        IDbPagedResult<IDbGegoennteBank> GetGegoennteBanken();

        IEnumerable<IDbGegoennteBank> GetAllGegoennteBanken();

        void UpdateGegoennteBank(IDbGegoennteBank gegoennteBank);
    }
}