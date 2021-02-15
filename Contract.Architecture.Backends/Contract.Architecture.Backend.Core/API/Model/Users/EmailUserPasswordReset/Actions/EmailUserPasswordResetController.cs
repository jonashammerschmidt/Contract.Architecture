using Contract.Architecture.Backend.Core.API.Services.RequestEmailUserAgentInfo;
using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Model.Users.EmailUserPasswordReset;
using Microsoft.AspNetCore.Mvc;

namespace Contract.Architecture.Backend.Core.API.Model.Users.EmailUserPasswordReset
{
    [ApiController]
    [Route("api/users/email-user")]
    public class EmailUserPasswordResetController : ControllerBase
    {
        private readonly IEmailUserPasswordResetLogic emailUserPasswordResetLogic;

        public EmailUserPasswordResetController(
            IEmailUserPasswordResetLogic emailUserPasswordResetLogic)
        {
            this.emailUserPasswordResetLogic = emailUserPasswordResetLogic;
        }

        [HttpPost]
        [Route("forgot-password")]
        public ActionResult ForgotPassword([FromBody] ForgotPassword forgotPassword)
        {
            var browser = RequestEmailUserAgentInfo.GetBrowser(this.Request);
            var operatingSystem = RequestEmailUserAgentInfo.GetOperatingSystem(this.Request);

            ILogicResult result = this.emailUserPasswordResetLogic.InitializePasswordReset(forgotPassword.Email, new BrowserInfo()
            {
                Browser = browser,
                OperatingSystem = operatingSystem
            });

            return this.FromLogicResult(result);
        }

        [HttpPut]
        [Route("reset-password")]
        public ActionResult ResetPassword([FromBody] ResetPassword resetPassword)
        {
            ILogicResult result = this.emailUserPasswordResetLogic.ResetPassword(resetPassword.Token, resetPassword.NewPassword);
            return this.FromLogicResult(result);
        }
    }
}