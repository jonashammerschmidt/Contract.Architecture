using Contract.Architecture.Backend.Core.Contract.Logic.Services.Time;
using Contract.Architecture.Backend.Core.Contract.Persistence.Model.Sessions.Sessions;
using Contract.Architecture.Backend.Core.Logic.Model.Sessions.Sessions;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Model.Sessions
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
            Mock<IDateTimeService> dateTimeService = SetupDateTimeServiceDefault();

            SessionExpirationScheduledJob scheduledJob = new SessionExpirationScheduledJob(
                sessionsRepository.Object,
                dateTimeService.Object,
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

        private static Mock<IDateTimeService> SetupDateTimeServiceDefault()
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
    }
}