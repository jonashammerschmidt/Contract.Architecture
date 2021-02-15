using Contract.Architecture.Backend.Core.Contract;
using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Model.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Password;
using Contract.Architecture.Backend.Core.Contract.Persistence.Model.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Logic.LogicResults;
using Microsoft.Extensions.Logging;

namespace Contract.Architecture.Backend.Core.Logic.Model.Users.EmailUsers
{
    internal class EmailUserPasswordChangeLogic : IEmailUserPasswordChangeLogic
    {
        private readonly IEmailUsersRepository emailUsersRepository;

        private readonly IBsiPasswordService bsiPasswordService;
        private readonly ISessionContext sessionContext;
        private readonly ILogger<EmailUserPasswordChangeLogic> logger;

        public EmailUserPasswordChangeLogic(
            IEmailUsersRepository emailUsersRepository,
            IBsiPasswordService bsiPasswordService,
            ISessionContext sessionContext,
            ILogger<EmailUserPasswordChangeLogic> logger)
        {
            this.emailUsersRepository = emailUsersRepository;

            this.bsiPasswordService = bsiPasswordService;
            this.sessionContext = sessionContext;
            this.logger = logger;
        }

        public ILogicResult ChangePassword(string oldPassword, string newPassword)
        {
            IDbEmailUser emailUser = this.emailUsersRepository.GetEmailUser(this.sessionContext.EmailUserId);
            if (!this.IsPasswordValid(oldPassword, emailUser))
            {
                this.logger.LogWarning("Das alte Passwort ist falsch.");
                return LogicResult.Forbidden();
            }

            this.UpdateEmailUserWithNewPassword(emailUser, newPassword);

            this.logger.LogInformation("Das Passwort wurde mit der Passwort-Ändern-Funktion neu vergeben.");
            return LogicResult.Ok();
        }

        private void UpdateEmailUserWithNewPassword(IDbEmailUser emailUser, string newPassword)
        {
            IBSIPasswordHash hash = this.bsiPasswordService.HashPassword(newPassword);
            emailUser.PasswordHash = hash.PasswordHash;
            emailUser.PasswordSalt = hash.Salt;
            this.emailUsersRepository.UpdateEmailUser(emailUser);
        }

        private bool IsPasswordValid(string password, IDbEmailUser emailUser)
        {
            return this.bsiPasswordService.ComparePasswords(password, emailUser.PasswordHash, emailUser.PasswordSalt);
        }
    }
}