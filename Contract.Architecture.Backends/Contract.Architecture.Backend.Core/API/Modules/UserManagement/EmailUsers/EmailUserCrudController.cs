using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.UserManagement.EmailUsers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Contract.Architecture.Backend.Core.API.Modules.Users.EmailUsers
{
    [ApiController]
    [Route("api/users/email-user")]
    public class EmailUserCrudController : ControllerBase
    {
        private readonly IEmailUserCrudLogic emailUsersLogic;

        public EmailUserCrudController(
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