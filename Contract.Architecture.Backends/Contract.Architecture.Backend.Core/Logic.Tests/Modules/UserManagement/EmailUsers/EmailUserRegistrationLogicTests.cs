using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Identifier;
using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Password;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.UserManagement.EmailUsers;
using Contract.Architecture.Backend.Core.Logic.Modules.UserManagement.EmailUsers;
using Contract.Architecture.Backend.Core.Logic.Tools.Password;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.UserManagement.EmailUsers
{
    [TestClass]
    public class EmailUserRegistrationLogicTests
    {
        private static readonly Guid EmailUserId = Guid.Parse("59f7717b-4647-4d33-9da4-b2a6a7d126c5");
        private static readonly string Email = "test@example.org";
        private static readonly string Password = "123QWEasd!";
        private static readonly string Hash = "lLj3sQPf1isP6T1CZWZ9RMN3W9okAdTk4OjooKHO+9BT5tJ55euCLde8ifSl6ru6SuaypWRiE1nkiZPNHDbu4A==";
        private static readonly string Salt = "50000.voYJdI+L2w/atDbVrWlMRUw8MkmXeBO9c35Ms2wQZfYQkw==";

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
            Mock<IPasswordHasher> passwordHasher = this.SetupPasswordHasherDefault();
            Mock<IGuidGenerator> guidGeneration = this.SetupGuidGeneratorDefault();
            var logger = Mock.Of<ILogger<EmailUserCrudLogic>>();

            EmailUserCrudLogic emailUserRegistrationLogic = new EmailUserCrudLogic(
                emailUsersRepository.Object,
                passwordHasher.Object,
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
                PasswordHash = Hash,
                PasswordSalt = Salt,
            };
        }

        private Mock<IPasswordHasher> SetupPasswordHasherDefault()
        {
            var passwordHasher = new Mock<IPasswordHasher>(MockBehavior.Strict);
            passwordHasher.Setup(service => service.HashPassword(It.IsAny<string>())).Returns((string passwort) =>
            {
                Assert.AreEqual(Password, passwort);
                return new PasswordHash()
                {
                    Hash = Hash,
                    Salt = Salt
                };
            });
            return passwordHasher;
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
                Assert.AreEqual(Hash, dbEmailUser.PasswordHash);
                Assert.AreEqual(Salt, dbEmailUser.PasswordSalt);
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