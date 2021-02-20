using Contract.Architecture.Backend.Core.Contract;
using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
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
    public class EmailUserPasswordChangeLogicTests
    {
        private static readonly string Email = "test@example.org";
        private static readonly Guid EmailUserId = Guid.Parse("59f7717b-4647-4d33-9da4-b2a6a7d126c5");
        private static readonly string Password = "123QWEasd!";
        private static readonly string PasswordHash = "lLj3sQPf1isP6T1CZWZ9RMN3W9okAdTk4OjooKHO+9BT5tJ55euCLde8ifSl6ru6SuaypWRiE1nkiZPNHDbu4A==";
        private static readonly string PasswordNew = "90ßIOPklö!";
        private static readonly string PasswordNewHash = "3W9okAdTk4OjooKHO+9BlLj3sQPf1isP6T1CZWZ9RMNT5tJ55euCLde8ifSl6ru6SuaypWRiE1nkiZPNHDbu4A==";
        private static readonly string PasswordNewSalt = "50000.8MkmXeBO9c35voYJdI+L2w/atDbVrWlMRUwMs2wQZfYQkw==";
        private static readonly string PasswordSalt = "50000.voYJdI+L2w/atDbVrWlMRUw8MkmXeBO9c35Ms2wQZfYQkw==";

        [TestMethod]
        public void ResetPasswordTest()
        {
            // Arrange
            Mock<IEmailUsersRepository> emailUsersRepository = this.SetupEmailUsersRepositoryExisting();
            Mock<IPasswordHasher> PasswordHasher = this.SetupPasswordHasherDefault();
            Mock<ISessionContext> sessionContext = this.SetupSessionContextDefault();

            EmailUserPasswordChangeLogic emailUserPasswordChangeLogic = new EmailUserPasswordChangeLogic(
                emailUsersRepository.Object,
                PasswordHasher.Object,
                sessionContext.Object,
                Mock.Of<ILogger<EmailUserPasswordChangeLogic>>());

            // Act
            var result = emailUserPasswordChangeLogic.ChangePassword(Password, PasswordNew);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
        }

        [TestMethod]
        public void ResetPasswordWrongOldPasswordTest()
        {
            // Arrange
            Mock<IEmailUsersRepository> emailUsersRepository = this.SetupEmailUsersRepositoryExisting();
            Mock<IPasswordHasher> PasswordHasher = this.SetupPasswordHasherComparePasswordsFailes();
            Mock<ISessionContext> sessionContext = this.SetupSessionContextDefault();

            EmailUserPasswordChangeLogic emailUserPasswordChangeLogic = new EmailUserPasswordChangeLogic(
                emailUsersRepository.Object,
                PasswordHasher.Object,
                sessionContext.Object,
                Mock.Of<ILogger<EmailUserPasswordChangeLogic>>());

            // Act
            var result = emailUserPasswordChangeLogic.ChangePassword(Password, PasswordNew);

            // Assert
            Assert.AreEqual(LogicResultState.Forbidden, result.State);
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

        private Mock<IPasswordHasher> SetupPasswordHasherComparePasswordsFailes()
        {
            var PasswordHasher = new Mock<IPasswordHasher>(MockBehavior.Strict);
            PasswordHasher.Setup(service => service.ComparePasswords(Password, PasswordHash, PasswordSalt)).Returns(false);
            return PasswordHasher;
        }

        private Mock<ISessionContext> SetupSessionContextDefault()
        {
            var sessionContext = new Mock<ISessionContext>(MockBehavior.Strict);
            sessionContext.Setup(service => service.EmailUserId).Returns(EmailUserId);
            return sessionContext;
        }

        private Mock<IPasswordHasher> SetupPasswordHasherDefault()
        {
            var PasswordHasher = new Mock<IPasswordHasher>(MockBehavior.Strict);
            PasswordHasher.Setup(service => service.ComparePasswords(Password, PasswordHash, PasswordSalt)).Returns(true);
            PasswordHasher.Setup(service => service.HashPassword(PasswordNew)).Returns((string passwort) =>
            {
                return new PasswordHash()
                {
                    PasswordHash = PasswordNewHash,
                    Salt = PasswordNewSalt
                };
            });
            return PasswordHasher;
        }

        private Mock<IEmailUsersRepository> SetupEmailUsersRepositoryExisting()
        {
            var emailUsersRepository = new Mock<IEmailUsersRepository>(MockBehavior.Strict);
            emailUsersRepository.Setup(repository => repository.GetEmailUser(EmailUserId)).Returns(this.CreateDbEmailUser());
            emailUsersRepository.Setup(repository => repository.UpdateEmailUser(It.IsAny<IDbEmailUser>())).Callback((IDbEmailUser dbEmailUser) =>
            {
                Assert.AreEqual(EmailUserId, dbEmailUser.Id);
                Assert.AreEqual(Email, dbEmailUser.Email);
                Assert.AreEqual(PasswordNewHash, dbEmailUser.PasswordHash);
                Assert.AreEqual(PasswordNewSalt, dbEmailUser.PasswordSalt);
            });
            return emailUsersRepository;
        }
    }
}