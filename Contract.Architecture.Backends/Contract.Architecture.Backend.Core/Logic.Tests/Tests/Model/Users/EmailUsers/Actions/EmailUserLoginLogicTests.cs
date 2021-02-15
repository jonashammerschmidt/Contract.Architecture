using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Model.Sessions.Sessions;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Password;
using Contract.Architecture.Backend.Core.Contract.Persistence.Model.Users.EmailUsers;
using Contract.Architecture.Backend.Core.Logic.Model.Users.EmailUsers;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Model.Users.EmailUsers
{
    [TestClass]
    public class EmailUserLoginLogicTests
    {
        private static readonly string Email = "test@example.org";
        private static readonly Guid EmailUserId = Guid.Parse("a4533231-7b3d-44c5-b843-3cc5e6ddc3c6");
        private static readonly string Passwort = "123QWEasd!";
        private static readonly string PasswortHash = "W2GqceACcOzpD35Ru1gCHItPxuuU4dDmEjUh2sSrx3CzCPyrHFE4yB//b04hvhg/qa+SbDgtjMCw+ieB/2LMWw==";
        private static readonly string PasswortSalt = "50000.whrsTXOmO7t8zi74xRIT4qOfdV6S8VaxGX1uHkNKn5OFTQ==";

        private static readonly string Token = "UDGywIO7BEWT269CsJekdwrp0eZto8TEGKmAEE6hHt4Q";

        [TestMethod]
        public void LoginAsEmailUserNotFoundTest()
        {
            // Arrange
            Mock<IEmailUsersRepository> emailUsersRepository = this.SetupEmailUsersRepositoryNotFound();
            Mock<IBsiPasswordService> bsiPasswordService = this.BsiPasswordServiceDefaultComparePasswords();

            EmailUserLoginLogic emailUserLoginLogic = new EmailUserLoginLogic(
                emailUsersRepository.Object,
                null,
                bsiPasswordService.Object,
                Mock.Of<ILogger<EmailUserLoginLogic>>());

            // Act
            ILogicResult<string> result = emailUserLoginLogic.LoginAsEmailUser(Email, Passwort);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void LoginAsEmailUserPasswordNotFoundTest()
        {
            // Arrange
            Mock<IEmailUsersRepository> emailUsersRepository = this.EmailUsersRepositoryDefaultGetEmailUser();
            Mock<IBsiPasswordService> bsiPasswordService = this.BsiPasswordServiceFailingComparePasswords();

            EmailUserLoginLogic emailUserLoginLogic = new EmailUserLoginLogic(
                emailUsersRepository.Object,
                null,
                bsiPasswordService.Object,
                Mock.Of<ILogger<EmailUserLoginLogic>>());

            // Act
            ILogicResult<string> result = emailUserLoginLogic.LoginAsEmailUser(Email, Passwort);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void LoginAsEmailUserTest()
        {
            // Arrange
            Mock<IEmailUsersRepository> emailUsersRepository = this.EmailUsersRepositoryDefaultGetEmailUser();
            Mock<IBsiPasswordService> bsiPasswordService = this.BsiPasswordServiceDefaultComparePasswords();
            Mock<ISessionsCrudLogic> sessionsLogic = this.SessionsLogicDefaultCreateSessionForEmailUser();

            EmailUserLoginLogic emailUserLoginLogic = new EmailUserLoginLogic(
                emailUsersRepository.Object,
                sessionsLogic.Object,
                bsiPasswordService.Object,
                Mock.Of<ILogger<EmailUserLoginLogic>>());

            // Act
            ILogicResult<string> result = emailUserLoginLogic.LoginAsEmailUser(Email, Passwort);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            Assert.AreEqual(Token, result.Data);
        }

        private Mock<IBsiPasswordService> BsiPasswordServiceDefaultComparePasswords()
        {
            Mock<IBsiPasswordService> bsiPasswordService = new Mock<IBsiPasswordService>(MockBehavior.Strict);
            bsiPasswordService.Setup(service => service.ComparePasswords(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string passwordToHash, string passwordHash, string passwordSalt) =>
                {
                    Assert.AreEqual(passwordToHash, Passwort);
                    Assert.AreEqual(passwordHash, PasswortHash);
                    Assert.AreEqual(passwordSalt, PasswortSalt);
                    return true;
                });
            return bsiPasswordService;
        }

        private Mock<IBsiPasswordService> BsiPasswordServiceFailingComparePasswords()
        {
            Mock<IBsiPasswordService> bsiPasswordService = new Mock<IBsiPasswordService>(MockBehavior.Strict);
            bsiPasswordService.Setup(service => service.ComparePasswords(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string passwordToHash, string passwordHash, string passwordSalt) =>
                {
                    Assert.AreEqual(passwordToHash, Passwort);
                    Assert.AreEqual(passwordHash, PasswortHash);
                    Assert.AreEqual(passwordSalt, PasswortSalt);
                    return false;
                });
            return bsiPasswordService;
        }

        private Mock<IEmailUsersRepository> EmailUsersRepositoryDefaultGetEmailUser()
        {
            Mock<IEmailUsersRepository> emailUsersRepository = new Mock<IEmailUsersRepository>(MockBehavior.Strict);
            emailUsersRepository.Setup(repository => repository.GetEmailUser(It.IsAny<string>())).Returns((string email) =>
            {
                Assert.AreEqual(Email, email);
                return new DbEmailUser()
                {
                    Id = EmailUserId,
                    Email = Email,
                    PasswordHash = PasswortHash,
                    PasswordSalt = PasswortSalt,
                };
            });
            return emailUsersRepository;
        }

        private Mock<ISessionsCrudLogic> SessionsLogicDefaultCreateSessionForEmailUser()
        {
            Mock<ISessionsCrudLogic> sessionsLogic = new Mock<ISessionsCrudLogic>(MockBehavior.Strict);
            sessionsLogic.Setup(logic => logic.CreateSessionForEmailUser(It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns((Guid emailUserId, string name) =>
                {
                    Assert.AreEqual(EmailUserId, emailUserId);
                    Assert.AreEqual(Email, name);
                    return Token;
                });
            return sessionsLogic;
        }

        private Mock<IEmailUsersRepository> SetupEmailUsersRepositoryNotFound()
        {
            Mock<IEmailUsersRepository> emailUsersRepository = new Mock<IEmailUsersRepository>(MockBehavior.Strict);
            emailUsersRepository.Setup(repository => repository.GetEmailUser(It.IsAny<string>())).Returns((string email) =>
            {
                return null;
            });
            return emailUsersRepository;
        }
    }
}