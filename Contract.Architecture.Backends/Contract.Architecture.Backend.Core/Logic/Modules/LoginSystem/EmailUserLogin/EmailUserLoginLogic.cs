using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Sessions.Sessions;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Password;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Logic.LogicResults;
using Microsoft.Extensions.Logging;

namespace Contract.Architecture.Backend.Core.Logic.Modules.Users.EmailUsers
{
    internal class EmailUserLoginLogic : IEmailUserLoginLogic
    {
        private readonly IEmailUsersRepository emailUsersRepository;
        private readonly ISessionsCrudLogic sessionsLogic;

        private readonly IPasswordHasher PasswordHasher;
        private readonly ILogger<EmailUserLoginLogic> logger;

        public EmailUserLoginLogic(
            IEmailUsersRepository emailUsersRepository,
            ISessionsCrudLogic sessionsLogic,
            IPasswordHasher PasswordHasher,
            ILogger<EmailUserLoginLogic> logger)
        {
            this.emailUsersRepository = emailUsersRepository;
            this.sessionsLogic = sessionsLogic;

            this.PasswordHasher = PasswordHasher;
            this.logger = logger;
        }

        public ILogicResult<string> LoginAsEmailUser(string email, string password)
        {
            var validateLoginDataResult = this.ValidateLoginData(email, password);
            if (!validateLoginDataResult.IsSuccessful)
            {
                return LogicResult<string>.Forward(validateLoginDataResult);
            }

            var emailUser = validateLoginDataResult.Data;

            var sessionToken = this.sessionsLogic.CreateSessionForEmailUser(emailUser.Id, emailUser.Email);

            this.logger.LogInformation(
                "E-Mail-Benutzer-Login erfolgreich für {emailUsername}",
                emailUser.Email);

            return LogicResult<string>.Ok(sessionToken);
        }

        private ILogicResult<IDbEmailUser> ValidateLoginData(string email, string password)
        {
            email = email.ToLower();
            IDbEmailUser emailUser = this.emailUsersRepository.GetEmailUser(email);

            if (emailUser == null)
            {
                this.logger.LogWarning("E-Mail ({email}) nicht korrekt.", email);
                return LogicResult<IDbEmailUser>.NotFound("E-Mail oder Passwort nicht korrekt");
            }

            if (!this.IsPasswordValid(password, emailUser))
            {
                this.logger.LogWarning("Passwort nicht korrekt für {email}.", emailUser.Email);
                return LogicResult<IDbEmailUser>.NotFound("E-Mail oder Passwort nicht korrekt");
            }

            return LogicResult<IDbEmailUser>.Ok(emailUser);
        }

        private bool IsPasswordValid(string password, IDbEmailUser emailUser)
        {
            return this.PasswordHasher.ComparePasswords(password, emailUser.PasswordHash, emailUser.PasswordSalt);
        }
    }
}