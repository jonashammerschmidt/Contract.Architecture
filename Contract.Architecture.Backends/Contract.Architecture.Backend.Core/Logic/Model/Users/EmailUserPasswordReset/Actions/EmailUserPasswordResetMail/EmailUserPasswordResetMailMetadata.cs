using Contract.Architecture.Backend.Core.Contract.Logic.Model.Users.EmailUserPasswordReset;

namespace Contract.Architecture.Backend.Core.Logic.Model.Users.EmailUserPasswordReset
{
    internal class EmailUserPasswordResetMailMetadata
    {
        public string MailResetPasswordUrlPrefix { get; set; }

        public string MailHomepageUrl { get; set; }

        public string MailSupportUrl { get; set; }

        public string EmailUserEmail { get; set; }

        public string EmailUserPasswordResetToken { get; set; }

        public IBrowserInfo EmailUserBrowserInfo { get; set; }
    }
}