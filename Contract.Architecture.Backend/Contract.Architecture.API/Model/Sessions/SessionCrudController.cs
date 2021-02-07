﻿using Contract.Architecture.API.Security;
using Contract.Architecture.API.Security.Authorization;
using Contract.Architecture.Contract.Logic.LogicResults;
using Contract.Architecture.Contract.Logic.Model.Sessions.Sessions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Contract.Architecture.API.Model.Sessions
{
    [ApiController]
    [Route("api/session")]
    public class SessionCrudController : ControllerBase
    {
        private readonly ISessionsCrudLogic sessionsLogic;

        private readonly ILogger<SessionCrudController> logger;

        public SessionCrudController(
            ISessionsCrudLogic sessionsLogic,
            ILogger<SessionCrudController> logger)
        {
            this.sessionsLogic = sessionsLogic;
            this.logger = logger;
        }

        [HttpGet]
        [Authorized]
        public ActionResult<ISession> GetSession()
        {
            string token = this.User.GetSessionToken();

            ILogicResult<ISession> sessionResult = this.sessionsLogic.GetSessionFromToken(token);

            return this.FromLogicResult(sessionResult);
        }

        [HttpDelete]
        [Authorized]
        [Route("logout")]
        public ActionResult Logout()
        {
            string token = this.User.GetSessionToken();
            ILogicResult terminateSessionResult = this.sessionsLogic.TerminateSession(token);

            this.logger.LogInformation("Logout successful");
            return this.FromLogicResult(terminateSessionResult);
        }
    }
}