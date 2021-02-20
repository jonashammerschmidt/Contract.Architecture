using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Identifier;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Password;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Logic.LogicResults;
using Microsoft.Extensions.Logging;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Modules.Users.EmailUsers
{
    internal class EmailUserCrudLogic : IEmailUserCrudLogic
    {
        private readonly IEmailUsersRepository emailUsersRepository;

        private readonly IPasswordHasher PasswordHasher;
        private readonly IGuidGenerator guidGenerator;
        private readonly ILogger<EmailUserCrudLogic> logger;

        public EmailUserCrudLogic(
            IEmailUsersRepository emailUsersRepository,
            IPasswordHasher PasswordHasher,
            IGuidGenerator guidGenerator,
            ILogger<EmailUserCrudLogic> logger)
        {
            this.emailUsersRepository = emailUsersRepository;

            this.PasswordHasher = PasswordHasher;
            this.guidGenerator = guidGenerator;
            this.logger = logger;
        }

        public ILogicResult<Guid> CreateEmailUser(IEmailUserCreate emailUserCreate)
        {
            emailUserCreate.Email = emailUserCreate.Email.ToLower();
            if (this.emailUsersRepository.GetEmailUser(emailUserCreate.Email) != null)
            {
                this.logger.LogDebug("EmailUser mit dieser E-Mail-Addresse existiert bereits.");
                return LogicResult<Guid>.Conflict("EmailUser mit dieser E-Mail-Addresse existiert bereits.");
            }

            DbEmailUser emailUserToAdd = this.CreateNewEmailUser(emailUserCreate);

            this.emailUsersRepository.CreateEmailUser(emailUserToAdd);

            this.logger.LogInformation("EmailUser ({email}) angelegt", emailUserCreate.Email);
            return LogicResult<Guid>.Ok(emailUserToAdd.Id);
        }

        private DbEmailUser CreateNewEmailUser(IEmailUserCreate emailUserCreate)
        {
            IPasswordHash passwordHash = this.PasswordHasher.HashPassword(emailUserCreate.Password);

            return new DbEmailUser()
            {
                Id = this.guidGenerator.NewGuid(),
                Email = emailUserCreate.Email,
                PasswordHash = passwordHash.PasswordHash,
                PasswordSalt = passwordHash.Salt
            };
        }
    }
}