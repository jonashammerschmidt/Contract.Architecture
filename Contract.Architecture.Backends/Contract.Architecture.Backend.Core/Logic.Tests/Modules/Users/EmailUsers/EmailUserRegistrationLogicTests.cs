using Contract.Architecture.Backend.Core.API.Modules.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Identifier;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Password;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Logic.Modules.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Logic.Services.Password;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Users.EmailUsers
{
    [TestClass]
    public class EmailUserRegistrationLogicTests
    {
        private static readonly Guid EmailUserId = Guid.Parse("59f7717b-4647-4d33-9da4-b2a6a7d126c5");
        private static readonly string Email = "test@example.org";
        private static readonly string Password = "123QWEasd!";
        private static readonly string PasswordHash = "lLj3sQPf1isP6T1CZWZ9RMN3W9okAdTk4OjooKHO+9BT5tJ55euCLde8ifSl6ru6SuaypWRiE1nkiZPNHDbu4A==";
        private static readonly string PasswordSalt = "50000.voYJdI+L2w/atDbVrWlMRUw8MkmXeBO9c35Ms2wQZfYQkw==";

        [TestMethod]
        public void RegisterConflictTest()
        {
            // Arrange
            Mock<IEmailUsersRepository> emailUsersRepository = this.SetupEmailUsersRepositoryExisting();
            var logger = Mock.Of<ILogger<EmailUserCrudLogic>>();

            EmailUserCrudLogic emailUserRegistrationLogic = new EmailUserCrudLogic(
                emailUsersRepository.Object,
                null,
                null,
                logger);

            // Act
            var result = emailUserRegistrationLogic.CreateEmailUser(new EmailUserCreate()
            {
                Email = Email,
                Password = Password
            });

            // Assert
            Assert.AreEqual(LogicResultState.Conflict, result.State);
        }

        [TestMethod]
        public void RegisterTest()
        {
            // Arrange
            Mock<IEmailUsersRepository> emailUsersRepository = this.SetupEmailUsersRepositoryNotExisting();
            Mock<IBsiPasswordService> bsiPasswordService = this.SetupBsiPasswordServiceDefault();
            Mock<IGuidGenerator> guidGeneration = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<EmailUserCrudLogic>>();

            EmailUserCrudLogic emailUserRegistrationLogic = new EmailUserCrudLogic(
                emailUsersRepository.Object,
                bsiPasswordService.Object,
                guidGeneration.Object,
                logger);

            // Act
            var result = emailUserRegistrationLogic.CreateEmailUser(new EmailUserCreate()
            {
                Email = Email,
                Password = Password
            });

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            emailUsersRepository.Verify(repository => repository.CreateEmailUser(It.IsAny<IDbEmailUser>()), Times.Once);
        }

        private DbEmailUser CreateDbEmailUser()
        {
            return new DbEmailUser()
            {
                Id = EmailUserId,
                Email = Email,
                PasswordHash = PasswordHash,
                PasswordSalt = PasswordSalt,
            };
        }

        private Mock<IBsiPasswordService> SetupBsiPasswordServiceDefault()
        {
            var bsiPasswordService = new Mock<IBsiPasswordService>(MockBehavior.Strict);
            bsiPasswordService.Setup(service => service.HashPassword(It.IsAny<string>())).Returns((string passwort) =>
            {
                Assert.AreEqual(Password, passwort);
                return new BsiPasswordHash()
                {
                    PasswordHash = PasswordHash,
                    Salt = PasswordSalt
                };
            });
            return bsiPasswordService;
        }

        private Mock<IEmailUsersRepository> SetupEmailUsersRepositoryExisting()
        {
            var emailUsersRepository = new Mock<IEmailUsersRepository>(MockBehavior.Strict);
            emailUsersRepository.Setup(repository => repository.GetEmailUser(EmailUserId)).Returns(this.CreateDbEmailUser());
            emailUsersRepository.Setup(repository => repository.GetEmailUser(Email)).Returns(this.CreateDbEmailUser());
            emailUsersRepository.Setup(repository => repository.DeleteEmailUser(EmailUserId));
            return emailUsersRepository;
        }

        private Mock<IEmailUsersRepository> SetupEmailUsersRepositoryNotExisting()
        {
            var emailUsersRepository = new Mock<IEmailUsersRepository>(MockBehavior.Strict);
            emailUsersRepository.Setup(repository => repository.GetEmailUser(Email)).Returns(() => null);
            emailUsersRepository.Setup(repository => repository.CreateEmailUser(It.IsAny<IDbEmailUser>())).Callback((IDbEmailUser dbEmailUser) =>
            {
                Assert.AreEqual(EmailUserId, dbEmailUser.Id);
                Assert.AreEqual(Email, dbEmailUser.Email);
                Assert.AreEqual(PasswordHash, dbEmailUser.PasswordHash);
                Assert.AreEqual(PasswordSalt, dbEmailUser.PasswordSalt);
            });
            return emailUsersRepository;
        }

        private Mock<IGuidGenerator> SetupGuidGeneratorDefault()
        {
            var guidGeneration = new Mock<IGuidGenerator>(MockBehavior.Strict);
            guidGeneration.Setup(generator => generator.NewGuid()).Returns(EmailUserId);
            return guidGeneration;
        }
    }
}