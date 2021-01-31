﻿using Contract.Architecture.Contract.Logic.Services.Email;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Mail;

namespace Contract.Architecture.Logic.Services.Email
{
    internal class EmailService : IEmailService, IDisposable
    {
        private readonly ILogger<EmailService> logger;

        private SmtpClient smtpClient;

        private string senderMailAddress = "noreply@example.org";

        private bool disposedValue = false; // To detect redundant calls

        public EmailService(
            ILogger<EmailService> logger,
            IOptions<EmailServiceOptions> options)
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

        private void SetupSmtpClient(EmailServiceOptions options)
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