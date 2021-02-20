using System;

namespace Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Sessions.Sessions
{
    public interface IDbSession
    {
        string Token { get; set; }

        string Name { get; set; }

        DateTime ExpiresOn { get; set; }

        Guid? EmailUserId { get; set; }
    }
}