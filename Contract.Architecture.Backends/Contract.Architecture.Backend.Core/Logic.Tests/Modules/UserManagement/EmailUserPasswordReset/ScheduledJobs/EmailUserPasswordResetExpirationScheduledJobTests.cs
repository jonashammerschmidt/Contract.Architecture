using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Users.EmailUserPasswordReset;
using Contract.Architecture.Backend.Core.Logic.Modules.Users.EmailUserPasswordReset;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Users.EmailUserPasswordReset
{
    [TestClass]
    public class EmailUserPasswordResetExpirationScheduledJobTests
    {
        private static readonly int ExpirationTimeInMinutes = 30;
        private static readonly bool RunOnInitialization = true;

        [TestMethod]
        public void ExecuteTest()
        {
            // Arrange
            Mock<IEmailUserPasswordResetLogic> emailUserPasswordResetLogic = this.SetupEmailUserPasswordResetLogicDefault();

            EmailUserPasswordResetExpirationScheduledJob scheduledJob = new EmailUserPasswordResetExpirationScheduledJob(
                emailUserPasswordResetLogic.Object,
                this.SetupOptions());

            // Act
            scheduledJob.Execute();
            emailUserPasswordResetLogic.Verify(logic => logic.RemoveExpiredPasswordResetTokens(), Times.Once);
        }

        [TestMethod]
        public void GetDelayInSecondsTest()
        {
            // Arrange
            EmailUserPasswordResetExpirationScheduledJob scheduledJob = new EmailUserPasswordResetExpirationScheduledJob(
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
            EmailUserPasswordResetExpirationScheduledJob scheduledJob = new EmailUserPasswordResetExpirationScheduledJob(
                null,
                this.SetupOptions());

            // Act
            bool isExecutingOnInitialization = scheduledJob.IsExecutingOnInitialization();

            // Assert
            Assert.AreEqual(RunOnInitialization, isExecutingOnInitialization);
        }

        private Mock<IEmailUserPasswordResetLogic> SetupEmailUserPasswordResetLogicDefault()
        {
            Mock<IEmailUserPasswordResetLogic> emailUserPasswordResetLogic = new Mock<IEmailUserPasswordResetLogic>(MockBehavior.Strict);
            emailUserPasswordResetLogic.Setup(logic => logic.RemoveExpiredPasswordResetTokens());
            return emailUserPasswordResetLogic;
        }

        private IOptions<EmailUserPasswordResetOptions> SetupOptions()
        {
            return Options.Create(new EmailUserPasswordResetOptions()
            {
                RunOnInitialization = RunOnInitialization,
                ExpirationTimeInMinutes = ExpirationTimeInMinutes
            });
        }
    }
}