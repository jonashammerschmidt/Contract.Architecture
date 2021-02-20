using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using System;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.Users.EmailUsers
{
    public interface IEmailUserCrudLogic
    {
        ILogicResult<Guid> CreateEmailUser(IEmailUserCreate emailUserCreate);
    }
}