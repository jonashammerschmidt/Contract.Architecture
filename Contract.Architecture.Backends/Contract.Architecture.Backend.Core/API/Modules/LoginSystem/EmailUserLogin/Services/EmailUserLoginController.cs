using Contract.Architecture.Backend.Core.Contract.Logic.Modules.LoginSystem.EmailUserLogin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contract.Architecture.Backend.Core.API.Modules.LoginSystem.EmailUserLogin
{
    [ApiController]
    [Route("api/users/email-user")]
    public class EmailUserLoginController : ControllerBase
    {
        private readonly IEmailUserLoginLogic emailUserLoginLogic;

        public EmailUserLoginController(
            IEmailUserLoginLogic emailUserLoginLogic)
        {
            this.emailUserLoginLogic = emailUserLoginLogic;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult<DataBody<string>> LoginAsEmailUser([FromBody] EmailUserLogin emailUserLogin)
        {
            var loginAsEmailUserResult = this.emailUserLoginLogic.LoginAsEmailUser(emailUserLogin.Email, emailUserLogin.Password);

            if (!loginAsEmailUserResult.IsSuccessful)
            {
                return this.FromLogicResult(loginAsEmailUserResult);
            }

            return this.Ok(new DataBody<string>(loginAsEmailUserResult.Data));
        }
    }
}