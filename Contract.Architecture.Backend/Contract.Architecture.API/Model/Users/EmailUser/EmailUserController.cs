﻿using Contract.Architecture.Contract.Logic.LogicResults;
using Contract.Architecture.Contract.Logic.Model.Users.EmailUsers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Contract.Architecture.API.Model.Users.EmailUsers
{
    [ApiController]
    [Route("api/users/email-user")]
    public class EmailUserController : ControllerBase
    {
        private readonly IEmailUserCrudLogic emailUsersLogic;

        public EmailUserController(
            IEmailUserCrudLogic emailUsersLogic)
        {
            this.emailUsersLogic = emailUsersLogic;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult<DataBody<Guid>> CreateEmailUser([FromBody] EmailUserCreate emailUserCreate)
        {
            ILogicResult<Guid> createEmailUserResult = this.emailUsersLogic.CreateEmailUser(emailUserCreate);
            if (!createEmailUserResult.IsSuccessful)
            {
                return this.FromLogicResult(createEmailUserResult);
            }

            return this.Ok(new DataBody<Guid>(createEmailUserResult.Data));
        }
    }
}