﻿using Contract.Architecture.Contract.Logic.LogicResults;
using Contract.Architecture.Contract.Logic.Model.Users.EmailUsers;
using Contract.Architecture.Contract.Logic.Services.Identifier;
using Contract.Architecture.Contract.Logic.Services.Password;
using Contract.Architecture.Contract.Persistence.Model.Users.EmailUsers;
using Contract.Architecture.Logic.LogicResults;
using Microsoft.Extensions.Logging;
using System;

namespace Contract.Architecture.Logic.Model.Users.EmailUsers
{
    internal class EmailUserCrudLogic : IEmailUserCrudLogic
    {
        private readonly IEmailUsersRepository emailUsersRepository;

        private readonly IBsiPasswordService bsiPasswordService;
        private readonly IGuidGenerator guidGenerator;
        private readonly ILogger<EmailUserCrudLogic> logger;

        public EmailUserCrudLogic(
            IEmailUsersRepository emailUsersRepository,
            IBsiPasswordService bsiPasswordService,
            IGuidGenerator guidGenerator,
            ILogger<EmailUserCrudLogic> logger)
        {
            this.emailUsersRepository = emailUsersRepository;

            this.bsiPasswordService = bsiPasswordService;
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
            IBSIPasswordHash passwordHash = this.bsiPasswordService.HashPassword(emailUserCreate.Password);

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