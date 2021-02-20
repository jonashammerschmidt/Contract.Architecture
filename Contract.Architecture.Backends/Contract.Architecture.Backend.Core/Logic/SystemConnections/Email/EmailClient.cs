using Contract.Architecture.Backend.Core.Contract.Logic.Services.Email;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Mail;

namespace Contract.Architecture.Backend.Core.Logic.SystemConnections.Email
{
    internal class EmailClient : IEmailClient, IDisposable
    {
        private readonly ILogger<EmailClient> logger;

        private SmtpClient smtpClient;

        private string senderMailAddress = "noreply@example.org";

        private bool disposedValue = false; // To detect redundant calls

        public EmailClient(
            ILogger<EmailClient> logger,
            IOptions<EmailClientOptions> options)
        {
            this.logger = logger;

            this.SetupSmtpClient(options.Value);
        }

        public void Send(IEmail email)
        {
            MailMessage mailMessage = this.CreateMailMessage(email);
            this.logger.LogInformation("Sending mail to {emailadress}", email.To);
            this.smtpClient.Send(mailMessage);
            this.logger.LogInformation("Sent mail to {emailadress}", email.To);
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.smtpClient.Dispose();
                }

                this.disposedValue = true;
            }
        }

        private void SetupSmtpClient(EmailClientOptions options)
        {
            if (options.SmtpSender != null)
            {
                this.senderMailAddress = options.SmtpSender;
            }

            if (options.SmtpHost != null && options.SmtpPort.HasValue)
            {
                this.smtpClient = new SmtpClient(options.SmtpHost, options.SmtpPort.Value);
            }
            else
            {
                this.smtpClient = new SmtpClient();
            }

            this.smtpClient.EnableSsl = options.EnableSsl;
        }

        private MailMessage CreateMailMessage(IEmail email)
        {
            MailMessage message = new MailMessage
            {
                From = new MailAddress(this.senderMailAddress),
                Subject = email.Subject,
                IsBodyHtml = true,
                Body = email.Message
            };

            message.To.Add(email.To);

            return message;
        }
    }
}