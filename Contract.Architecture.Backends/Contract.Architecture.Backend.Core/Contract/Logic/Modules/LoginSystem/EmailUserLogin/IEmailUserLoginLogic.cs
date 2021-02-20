using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.LoginSystem.EmailUserLogin
{
    public interface IEmailUserLoginLogic
    {
        ILogicResult<string> LoginAsEmailUser(string email, string password);
    }
}