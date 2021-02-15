using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Sessions.Sessions;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.Sessions.Sessions
{
    public partial class DbSession : IDbSession
    {
        public string Token { get; set; }

        public string Name { get; set; }

        public DateTime ExpiresOn { get; set; }

        public Guid? EmailUserId { get; set; }

        public static IDbSession FromEfSession(EfSession efSession)
        {
            if (efSession == null)
            {
                return null;
            }

            DbSession dbSession = new DbSession()
            {
                Token = efSession.Token,
                Name = efSession.Name,
                ExpiresOn = efSession.ExpiresOn,
                EmailUserId = efSession.EmailUserId,
            };

            return dbSession;
        }

        public static EfSession ToEfSession(IDbSession dbSession)
        {
            return new EfSession()
            {
                Token = dbSession.Token,
                Name = dbSession.Name,
                ExpiresOn = dbSession.ExpiresOn,
                EmailUserId = dbSession.EmailUserId,
            };
        }
    }
}