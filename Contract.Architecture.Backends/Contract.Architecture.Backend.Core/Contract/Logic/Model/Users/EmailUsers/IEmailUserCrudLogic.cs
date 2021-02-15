using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using System;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Model.Users.EmailUsers
{
    public interface IEmailUserCrudLogic
    {
        ILogicResult<Guid> CreateEmailUser(IEmailUserCreate emailUserCreate);
    }
}