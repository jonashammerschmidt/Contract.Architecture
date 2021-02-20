using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Time;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.SessionManagement.Sessions;
using Contract.Architecture.Backend.Core.Logic.Modules.SessionManagement.Sessions;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.SessionManagement.Sessions
{
    [TestClass]
    public class SessionExpirationScheduledJobTests
    {
        private static readonly DateTime Now = DateTime.Now;

        private static readonly bool RunOnInitialization = true;
        private static readonly int ExpirationTimeInMinutes = 30;

        [TestMethod]
        public void GetDelayInSecondsTest()
        {
            // Arrange
            SessionExpirationScheduledJob scheduledJob = new SessionExpirationScheduledJob(
                null,
                null,
                this.SetupOptions());

            // Act
            var delayInSeconds = scheduledJob.GetDelayInSeconds();

            // Assert
            Assert.AreEqual(1800, delayInSeconds);
        }

        [TestMethod]
        public void IsExecutingOnInitializationTest()
        {
            // Arrange
            SessionExpirationScheduledJob scheduledJob = new SessionExpirationScheduledJob(
                null,
                null,
                this.SetupOptions());

            // Act
            var isExecutingOnInitialization = scheduledJob.IsExecutingOnInitialization();

            // Assert
            Assert.IsTrue(isExecutingOnInitialization);
        }

        [TestMethod]
        public void ExecuteTest()
        {
            // Arrange
            Mock<ISessionsRepository> sessionsRepository = SetupSessionsRepositoryDefault();
            Mock<IDateTimeProvider> dateTimeProvider = SetupDateTimeProviderDefault();

            SessionExpirationScheduledJob scheduledJob = new SessionExpirationScheduledJob(
                sessionsRepository.Object,
                dateTimeProvider.Object,
                this.SetupOptions());

            // Act
            scheduledJob.Execute();

            // Assert
            sessionsRepository.Verify(repository => repository.DeleteExpiredSessions(Now), Times.Once);
        }

        private static Mock<ISessionsRepository> SetupSessionsRepositoryDefault()
        {
            Mock<ISessionsRepository> sessionsRepository = new Mock<ISessionsRepository>(MockBehavior.Strict);
            sessionsRepository.Setup(repository => repository.DeleteExpiredSessions(Now));
            return sessionsRepository;
        }

        private static Mock<IDateTimeProvider> SetupDateTimeProviderDefault()
        {
            Mock<IDateTimeProvider> dateTimeProvider = new Mock<IDateTimeProvider>(MockBehavior.Strict);
            dateTimeProvider.Setup(service => service.Now()).Returns(() => Now);
            return dateTimeProvider;
        }

        private IOptions<SessionExpirationOptions> SetupOptions()
        {
            return Options.Create(new SessionExpirationOptions()
            {
                RunOnInitialization = RunOnInitialization,
                ExpirationTimeInMinutes = ExpirationTimeInMinutes
            });
        }
    }
}