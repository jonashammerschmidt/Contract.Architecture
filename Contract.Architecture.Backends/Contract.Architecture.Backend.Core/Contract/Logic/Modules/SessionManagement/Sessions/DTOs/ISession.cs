using System;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.SessionManagement.Sessions
{
    public interface ISession
    {
        DateTime ExpiresOn { get; set; }

        string Name { get; set; }

        string Token { get; set; }

        Guid? EmailUserId { get; set; }
    }
}