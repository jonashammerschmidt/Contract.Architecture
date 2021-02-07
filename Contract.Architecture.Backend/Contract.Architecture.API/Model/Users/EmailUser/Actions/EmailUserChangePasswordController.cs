﻿using Contract.Architecture.API.Security.Authorization;
using Contract.Architecture.Contract.Logic.LogicResults;
using Contract.Architecture.Contract.Logic.Model.Users.EmailUsers;
using Microsoft.AspNetCore.Mvc;

namespace Contract.Architecture.API.Model.Users.EmailUsers
{
    [ApiController]
    [Route("api/users/email-user")]
    public class EmailUserChangePasswordController : ControllerBase
    {
        private readonly IEmailUserPasswordChangeLogic emailUserPasswordChangeLogic;

        public EmailUserChangePasswordController(
            IEmailUserPasswordChangeLogic emailUserPasswordChangeLogic)
        {
            this.emailUserPasswordChangeLogic = emailUserPasswordChangeLogic;
        }

        [HttpPut]
        [Authorized]
        [Route("change-password")]
        public ActionResult ChangePassword([FromBody] ChangePassword changePassword)
        {
            ILogicResult result = this.emailUserPasswordChangeLogic.ChangePassword(
                changePassword.OldPassword,
                changePassword.NewPassword);
            return this.FromLogicResult(result);
        }
    }
}