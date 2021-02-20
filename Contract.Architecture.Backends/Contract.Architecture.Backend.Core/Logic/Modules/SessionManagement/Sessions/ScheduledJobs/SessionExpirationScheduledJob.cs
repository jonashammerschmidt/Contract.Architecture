using Contract.Architecture.Backend.Core.Contract.Logic.JobScheduler;
using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Time;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.SessionManagement.Sessions;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Contract.Architecture.Backend.Core.Logic.Modules.SessionManagement.Sessions
{
    internal class SessionExpirationScheduledJob : IScheduledJob
    {
        private readonly ISessionsRepository sessionsRepository;

        private readonly IDateTimeProvider dateTimeProvider;

        private readonly SessionExpirationOptions sessionExpirationOptions;

        public SessionExpirationScheduledJob(
            ISessionsRepository sessionsRepository,
            IDateTimeProvider dateTimeProvider,
            IOptions<SessionExpirationOptions> options)
        {
            this.sessionsRepository = sessionsRepository;

            this.dateTimeProvider = dateTimeProvider;

            this.sessionExpirationOptions = options.Value;
        }

        public int GetDelayInSeconds() => this.sessionExpirationOptions.ExpirationTimeInMinutes * 60;

        public bool IsExecutingOnInitialization() => this.sessionExpirationOptions.RunOnInitialization;

        public Task Execute()
        {
            this.sessionsRepository.DeleteExpiredSessions(this.dateTimeProvider.Now());

            return Task.CompletedTask;
        }
    }
}