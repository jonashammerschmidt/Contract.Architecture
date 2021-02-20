using System;
using System.IO;

namespace Contract.Architecture.Backend.Core.Logic.Modules.Users.EmailUserPasswordReset
{
    internal class EmailUserPasswordResetMail
    {
        private string mailContent;

        public EmailUserPasswordResetMail()
        {
        }

        public string GetMessage(EmailUserPasswordResetMailMetadata metadata)
        {
            if (this.mailContent == null)
            {
                this.LoadMailContent();
            }

            var message = this.GenerateMessageFromData(metadata);

            return message;
        }

        private string GenerateMessageFromData(EmailUserPasswordResetMailMetadata metadata)
        {
            var message = this.mailContent.ToString();

            message = message.Replace("{{name}}", metadata.EmailUserEmail);
            message = message.Replace("{{homepage_url}}", metadata.MailHomepageUrl);
            message = message.Replace("{{action_url}}", metadata.MailResetPasswordUrlPrefix + metadata.EmailUserPasswordResetToken);
            message = message.Replace("{{support_url}}", metadata.MailSupportUrl);
            message = message.Replace("{{operating_system}}", metadata.EmailUserBrowserInfo.OperatingSystem);
            message = message.Replace("{{browser_name}}", metadata.EmailUserBrowserInfo.Browser);

            return message;
        }

        private void LoadMailContent()
        {
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "EmailUserPasswordResetMail.html");
            this.mailContent = File.ReadAllText(file);
        }
    }
}