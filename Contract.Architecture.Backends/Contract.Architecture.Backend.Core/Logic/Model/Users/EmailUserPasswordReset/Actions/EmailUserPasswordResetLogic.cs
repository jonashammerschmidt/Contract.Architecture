using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Model.Users.EmailUserPasswordReset;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Email;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Identifier;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Password;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Time;
using Contract.Architecture.Backend.Core.Contract.Persistence.Model.Users.EmailUserPasswortReset;
using Contract.Architecture.Backend.Core.Contract.Persistence.Model.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Logic.Services.Email;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Contract.Architecture.Backend.Core.Logic.Model.Users.EmailUserPasswordReset
{
    internal class EmailUserPasswordResetLogic : IEmailUserPasswordResetLogic
    {
        private readonly IEmailUserPasswortResetTokensRepository emailUserPasswordResetTokenRepository;
        private readonly IEmailUsersRepository emailUsersRepository;

        private readonly IEmailService emailService;
        private readonly IBsiPasswordService bsiPasswordService;
        private readonly ISHA256TokenGenerator sha256TokenGenerator;
        private readonly IDateTimeService dateTimeService;
        private readonly ILogger<EmailUserPasswordResetLogic> logger;

        private readonly EmailUserPasswordResetOptions options;

        private readonly EmailUserPasswordResetMail mail;

        public EmailUserPasswordResetLogic(
            IEmailUserPasswortResetTokensRepository emailUserPasswordResetTokenRepository,
            IEmailUsersRepository emailUsersRepository,
            IEmailService emailService,
            IBsiPasswordService bsiPasswordService,
            ISHA256TokenGenerator sha256TokenGenerator,
            IDateTimeService dateTimeService,
            ILogger<EmailUserPasswordResetLogic> logger,
            IOptions<EmailUserPasswordResetOptions> options)
        {
            this.emailUserPasswordResetTokenRepository = emailUserPasswordResetTokenRepository;
            this.emailUsersRepository = emailUsersRepository;
            this.emailService = emailService;
            this.bsiPasswordService = bsiPasswordService;
            this.sha256TokenGenerator = sha256TokenGenerator;
            this.dateTimeService = dateTimeService;

            this.logger = logger;

            this.options = options.Value;

            this.mail = new EmailUserPasswordResetMail();
        }

        public ILogicResult InitializePasswordReset(string email, IBrowserInfo browserInfo)
        {
            var emailUser = this.emailUsersRepository.GetEmailUser(email);

            if (emailUser == null)
            {
                this.logger.LogDebug("EmailUser konnte nicht gefunden werden.");
                return LogicResult.NotFound("EmailUser konnte nicht gefunden werden.");
            }

            DbEmailUserPasswordResetToken token = this.CreateToken(emailUser);

            this.emailUserPasswordResetTokenRepository.CreateToken(token);

            this.SendPasswordResetMail(email, token, browserInfo);

            this.logger.LogInformation("Passwort-Reset wurde gestartet und eine Mail an {email} versendet", email);
            return LogicResult.Ok();
        }

        public ILogicResult ResetPassword(string emailUserPasswordResetToken, string newPassword)
        {
            var emailUserPasswordResetTokenInfo = this.emailUserPasswordResetTokenRepository.GetToken(emailUserPasswordResetToken);

            if (emailUserPasswordResetTokenInfo == null || emailUserPasswordResetTokenInfo.ExpiresOn <= this.dateTimeService.Now())
            {
                this.logger.LogDebug("EmailUserPasswordResetToken konnte nicht gefunden werden.");
                return LogicResult.NotFound("EmailUserPasswordResetToken konnte nicht gefunden werden.");
            }

            this.emailUserPasswordResetTokenRepository.DeleteToken(emailUserPasswordResetToken);

            IDbEmailUser emailUser = this.emailUsersRepository.GetEmailUser(emailUserPasswordResetTokenInfo.EmailUserId);
            this.UpdateEmailUserWithNewPassword(emailUser, newPassword);

            this.logger.LogInformation("Der EmailUser {email} hat sein Passwort über die Passwort-Zurücksetzen-Funktion neu vergeben", emailUser.Email);
            return LogicResult.Ok();
        }

        public void RemoveExpiredPasswordResetTokens()
        {
            this.emailUserPasswordResetTokenRepository.DeleteToken(this.dateTimeService.Now());
        }

        private DbEmailUserPasswordResetToken CreateToken(IDbEmailUser emailUser)
        {
            return new DbEmailUserPasswordResetToken()
            {
                Token = this.sha256TokenGenerator.Generate(),
                ExpiresOn = this.dateTimeService.Now().AddMinutes(this.options.ExpirationTimeInMinutes),
                EmailUserId = emailUser.Id
            };
        }

        private void SendPasswordResetMail(string email, DbEmailUserPasswordResetToken emailUserPasswordResetToken, IBrowserInfo browserInfo)
        {
            string mailMessage = this.mail.GetMessage(new EmailUserPasswordResetMailMetadata()
            {
                MailResetPasswordUrlPrefix = this.options.MailResetPasswordUrlPrefix,
                MailHomepageUrl = this.options.MailHomepageUrl,
                MailSupportUrl = this.options.MailSupportUrl,
                EmailUserEmail = email,
                EmailUserPasswordResetToken = emailUserPasswordResetToken.Token,
                EmailUserBrowserInfo = browserInfo
            });

            this.emailService.Send(new Email()
            {
                To = email,
                Subject = "[[Produktname]] Passwort zurücksetzen",
                Message = mailMessage
            });
        }

        private void UpdateEmailUserWithNewPassword(IDbEmailUser emailUser, string newPassword)
        {
            IBSIPasswordHash hash = this.bsiPasswordService.HashPassword(newPassword);
            emailUser.PasswordHash = hash.PasswordHash;
            emailUser.PasswordSalt = hash.Salt;
            this.emailUsersRepository.UpdateEmailUser(emailUser);
        }
    }
}