using System;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Model.Sessions.Sessions
{
    public interface ISession
    {
        DateTime ExpiresOn { get; set; }

        string Name { get; set; }

        string Token { get; set; }

        Guid? EmailUserId { get; set; }
    }
}