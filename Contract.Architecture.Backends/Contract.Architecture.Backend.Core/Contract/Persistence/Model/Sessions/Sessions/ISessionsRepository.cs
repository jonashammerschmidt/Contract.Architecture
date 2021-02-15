using System;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.Contract.Persistence.Model.Sessions.Sessions
{
    public interface ISessionsRepository
    {
        void CreateSession(IDbSession session);

        void DeleteExpiredSessions(DateTime now);

        void DeleteSession(string token);

        void DeleteSessionsOfEmailUser(Guid emailUserId);

        IDbSession GetSession(string token);

        List<IDbSession> GetSessionsOfEmailUser(Guid emailUserId);
    }
}