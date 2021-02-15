using Contract.Architecture.Backend.Core.Persistence.Model.Sessions.Sessions;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Mocking
{
    internal static class DbSessionMocking
    {
        internal static DbSession Create()
        {
            return Create(Guid.NewGuid().ToString());
        }

        internal static DbSession Create(string token)
        {
            return new DbSession()
            {
                Token = token,
                ExpiresOn = DateTime.Now.AddMinutes(30),
                EmailUserId = null,
            };
        }

        internal static DbSession CreateForEmailUser(Guid emailUserId, string token)
        {
            return new DbSession()
            {
                Token = token,
                ExpiresOn = DateTime.Now.AddMinutes(30),
                EmailUserId = emailUserId,
            };
        }
    }
}