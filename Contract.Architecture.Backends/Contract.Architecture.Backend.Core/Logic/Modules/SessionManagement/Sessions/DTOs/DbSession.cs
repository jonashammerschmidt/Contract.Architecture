using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Sessions.Sessions;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Modules.Sessions.Sessions
{
    internal class DbSession : IDbSession
    {
        public string Token { get; set; }

        public string Name { get; set; }

        public DateTime ExpiresOn { get; set; }

        public Guid? EmailUserId { get; set; }
    }
}