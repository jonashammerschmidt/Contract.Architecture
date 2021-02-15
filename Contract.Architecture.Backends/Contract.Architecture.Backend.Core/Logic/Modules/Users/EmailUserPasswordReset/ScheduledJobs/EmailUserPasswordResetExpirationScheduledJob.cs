using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Users.EmailUserPasswordReset;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.ScheduledJob;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Contract.Architecture.Backend.Core.Logic.Modules.Users.EmailUserPasswordReset
{
    internal class EmailUserPasswordResetExpirationScheduledJob : IScheduledJob
    {
        private readonly IEmailUserPasswordResetLogic emailUserPasswordResetLogic;

        private readonly EmailUserPasswordResetOptions options;

        public EmailUserPasswordResetExpirationScheduledJob(
            IEmailUserPasswordResetLogic emailUserPasswordResetLogic,
            IOptions<EmailUserPasswordResetOptions> options)
        {
            this.emailUserPasswordResetLogic = emailUserPasswordResetLogic;

            this.options = options.Value;
        }

        public int GetDelayInSeconds() => this.options.ExpirationTimeInMinutes * 60;

        public bool IsExecutingOnInitialization() => this.options.RunOnInitialization;

        public Task Execute()
        {
            this.emailUserPasswordResetLogic.RemoveExpiredPasswordResetTokens();

            return Task.CompletedTask;
        }
    }
}