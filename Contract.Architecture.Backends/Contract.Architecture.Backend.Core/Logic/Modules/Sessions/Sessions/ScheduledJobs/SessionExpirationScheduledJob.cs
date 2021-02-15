using Contract.Architecture.Backend.Core.Contract.Logic.Services.ScheduledJob;
using Contract.Architecture.Backend.Core.Contract.Logic.Services.Time;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Sessions.Sessions;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Contract.Architecture.Backend.Core.Logic.Modules.Sessions.Sessions
{
    internal class SessionExpirationScheduledJob : IScheduledJob
    {
        private readonly ISessionsRepository sessionsRepository;

        private readonly IDateTimeService dateTimeService;

        private readonly SessionExpirationOptions sessionExpirationOptions;

        public SessionExpirationScheduledJob(
            ISessionsRepository sessionsRepository,
            IDateTimeService dateTimeService,
            IOptions<SessionExpirationOptions> options)
        {
            this.sessionsRepository = sessionsRepository;

            this.dateTimeService = dateTimeService;

            this.sessionExpirationOptions = options.Value;
        }

        public int GetDelayInSeconds() => this.sessionExpirationOptions.ExpirationTimeInMinutes * 60;

        public bool IsExecutingOnInitialization() => this.sessionExpirationOptions.RunOnInitialization;

        public Task Execute()
        {
            this.sessionsRepository.DeleteExpiredSessions(this.dateTimeService.Now());

            return Task.CompletedTask;
        }
    }
}