﻿using Contract.Architecture.Contract.Logic.LogicResults;
using System;

namespace Contract.Architecture.Contract.Logic.Model.Sessions.Sessions
{
    public interface ISessionsCrudLogic
    {
        string CreateSessionForEmailUser(Guid emailUserId, string name);

        ILogicResult<ISession> GetSessionFromToken(string token);

        ILogicResult TerminateSession(string token);
    }
}