using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Sessions.Sessions;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Identifier;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Time;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Sessions.Sessions;
using Contract.Architecture.Backend.Core.Logic.Modules.Sessions.Sessions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Sessions
{
    [TestClass]
    public class SessionsLogicTests
    {
        private static readonly string EmailUserEmail = "test@example.org";
        private static readonly Guid EmailUserId = Guid.Parse("4e12b74c-b8f1-447e-bb5c-2fe86a10b76f");
        private static readonly int ExpirationTimeInMinutes = 30;
        private static readonly DateTime Now = DateTime.Now;
        private static readonly bool RunOnInitialization = true;
        private static readonly string Token = "UDGywIO7BEWT269CsJekdwrp0eZto8TEGKmAEE6hHt4Q";

        [TestMethod]
        public void CreateSessionForEmailUserTest()
        {
            // Arrange
            Mock<ISHA256TokenGenerator> sha256TokenGenerator = this.SetupSHA256TokenGenerator();
            Mock<ISessionsRepository> sessionsRepository = this.SetupSessionsRepositoryForEmailUser();

            SessionsCrudLogic sessionsLogic = new SessionsCrudLogic(
                sessionsRepository.Object,
                sha256TokenGenerator.Object,
                this.DateTimeServiceDefaultNow().Object,
                Mock.Of<ILogger<SessionsCrudLogic>>(),
                this.SetupOptions());

            // Act
            var token = sessionsLogic.CreateSessionForEmailUser(
                EmailUserId,
                EmailUserEmail);

            // Assert
            Assert.AreEqual(Token, token);
        }

        [TestMethod]
        public void GetEmailUserSessionFromToken()
        {
            // Arrange
            Mock<ISessionsRepository> sessionsRepository = this.SetupSessionsRepositoryForEmailUser();

            SessionsCrudLogic sessionsLogic = new SessionsCrudLogic(
                sessionsRepository.Object,
                null,
                this.DateTimeServiceDefaultNow().Object,
                Mock.Of<ILogger<SessionsCrudLogic>>(),
                this.SetupOptions());

            // Act
            ILogicResult<ISession> result = sessionsLogic.GetSessionFromToken(Token);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            ISession session = result.Data;

            Assert.AreEqual(Token, session.Token);
            Assert.AreEqual(EmailUserId, session.EmailUserId);
            Assert.IsNotNull(session.ExpiresOn);
        }

        [TestMethod]
        public void GetEmailUserSessionFromTokenSessionExpiredTest()
        {
            // Arrange
            Mock<ISessionsRepository> sessionsRepository = this.SetupSessionsRepositoryExpired();

            SessionsCrudLogic sessionsLogic = new SessionsCrudLogic(
                sessionsRepository.Object,
                null,
                this.DateTimeServiceDefaultNow().Object,
                Mock.Of<ILogger<SessionsCrudLogic>>(),
                this.SetupOptions());

            // Act
            ILogicResult<ISession> result = sessionsLogic.GetSessionFromToken(Token);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void GetEmailUserSessionFromTokenSessionFoundTest()
        {
            // Arrange
            Mock<ISessionsRepository> sessionsRepository = this.SetupSessionsRepositoryNotFound();

            SessionsCrudLogic sessionsLogic = new SessionsCrudLogic(
                sessionsRepository.Object,
                null,
                this.DateTimeServiceDefaultNow().Object,
                Mock.Of<ILogger<SessionsCrudLogic>>(),
                this.SetupOptions());

            // Act
            ILogicResult<ISession> result = sessionsLogic.GetSessionFromToken(Token);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        [TestMethod]
        public void TerminateSession()
        {
            // Arrange
            Mock<ISessionsRepository> sessionsRepository = this.SetupSessionsRepositoryForEmailUser();

            SessionsCrudLogic sessionsLogic = new SessionsCrudLogic(
                sessionsRepository.Object,
                null,
                this.DateTimeServiceDefaultNow().Object,
                Mock.Of<ILogger<SessionsCrudLogic>>(),
                this.SetupOptions());

            // Act
            ILogicResult result = sessionsLogic.TerminateSession(Token);

            // Assert
            Assert.AreEqual(LogicResultState.Ok, result.State);
            sessionsRepository.Verify(repository => repository.DeleteSession(Token), Times.Once);
        }

        [TestMethod]
        public void TerminateSessionNotFoundTest()
        {
            // Arrange
            Mock<ISessionsRepository> sessionsRepository = this.SetupSessionsRepositoryNotFound();

            SessionsCrudLogic sessionsLogic = new SessionsCrudLogic(
                sessionsRepository.Object,
                null,
                this.DateTimeServiceDefaultNow().Object,
                Mock.Of<ILogger<SessionsCrudLogic>>(),
                this.SetupOptions());

            // Act
            ILogicResult result = sessionsLogic.TerminateSession(Token);

            // Assert
            Assert.AreEqual(LogicResultState.NotFound, result.State);
        }

        private Mock<IDateTimeService> DateTimeServiceDefaultNow()
        {
            Mock<IDateTimeService> dateTimeService = new Mock<IDateTimeService>(MockBehavior.Strict);
            dateTimeService.Setup(service => service.Now()).Returns(() => Now);
            return dateTimeService;
        }

        private IOptions<SessionExpirationOptions> SetupOptions()
        {
            return Options.Create(new SessionExpirationOptions()
            {
                RunOnInitialization = RunOnInitialization,
                ExpirationTimeInMinutes = ExpirationTimeInMinutes
            });
        }

        private Mock<ISessionsRepository> SetupSessionsRepositoryExpired()
        {
            Mock<ISessionsRepository> sessionsRepository = new Mock<ISessionsRepository>(MockBehavior.Strict);
            sessionsRepository.Setup(repository => repository.GetSession(Token)).Returns(new DbSession()
            {
                Token = Token,
                ExpiresOn = DateTime.Now.AddMinutes(-30),
                Name = EmailUserEmail,
                EmailUserId = EmailUserId
            });
            return sessionsRepository;
        }

        private Mock<ISessionsRepository> SetupSessionsRepositoryForEmailUser()
        {
            Mock<ISessionsRepository> sessionsRepository = new Mock<ISessionsRepository>(MockBehavior.Strict);
            sessionsRepository.Setup(repository => repository.CreateSession(It.IsAny<IDbSession>())).Callback((IDbSession dbSession) =>
            {
                Assert.AreEqual(Token, dbSession.Token);
                Assert.AreEqual(EmailUserId, dbSession.EmailUserId);
                Assert.AreEqual(EmailUserEmail, dbSession.Name);
            });
            sessionsRepository.Setup(repository => repository.GetSession(Token)).Returns(new DbSession()
            {
                Token = Token,
                ExpiresOn = DateTime.Now.AddMinutes(30),
                Name = EmailUserEmail,
                EmailUserId = EmailUserId
            });
            sessionsRepository.Setup(repository => repository.DeleteSession(Token));
            return sessionsRepository;
        }

        private Mock<ISessionsRepository> SetupSessionsRepositoryNotFound()
        {
            Mock<ISessionsRepository> sessionsRepository = new Mock<ISessionsRepository>(MockBehavior.Strict);
            sessionsRepository.Setup(repository => repository.GetSession(Token)).Returns(() => { return null; });
            return sessionsRepository;
        }

        private Mock<ISHA256TokenGenerator> SetupSHA256TokenGenerator()
        {
            Mock<ISHA256TokenGenerator> sha256TokenGenerator = new Mock<ISHA256TokenGenerator>(MockBehavior.Strict);
            sha256TokenGenerator.Setup(generator => generator.Generate()).Returns(Token);
            return sha256TokenGenerator;
        }
    }
}