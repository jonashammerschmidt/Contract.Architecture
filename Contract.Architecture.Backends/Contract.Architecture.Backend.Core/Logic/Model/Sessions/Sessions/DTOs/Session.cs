using Contract.Architecture.Backend.Core.Contract.Logic.Model.Sessions.Sessions;
using Contract.Architecture.Backend.Core.Contract.Persistence.Model.Sessions.Sessions;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Model.Sessions.Sessions
{
    internal class Session : ISession
    {
        public string Token { get; set; }

        public string Name { get; set; }

        public DateTime ExpiresOn { get; set; }

        public Guid? EmailUserId { get; set; }

        public static Session FromDbSession(IDbSession session)
        {
            return new Session()
            {
                Token = session.Token,
                Name = session.Name,
                ExpiresOn = session.ExpiresOn,
                EmailUserId = session.EmailUserId,
            };
        }
    }
}