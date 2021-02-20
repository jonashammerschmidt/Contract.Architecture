using Contract.Architecture.Backend.Core.Contract.Logic.JobScheduler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Contract.Architecture.Backend.Core.Logic.JobSchedulers
{
    internal class JobScheduler<TScheduledJob> : IHostedService, IDisposable
        where TScheduledJob : IScheduledJob
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<TScheduledJob> logger;

        private readonly bool isExecutingOnInitialization;
        private readonly int delayInSeconds;

        private System.Timers.Timer timer;

        private bool disposedValue = false;

        public JobScheduler(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.logger = (ILogger<TScheduledJob>)this.serviceProvider.GetRequiredService(typeof(ILogger<TScheduledJob>));

            using (var scope = this.serviceProvider.CreateScope())
            {
                var executer = (TScheduledJob)scope.ServiceProvider.GetRequiredService(typeof(TScheduledJob));
                this.isExecutingOnInitialization = executer.IsExecutingOnInitialization();
                this.delayInSeconds = executer.GetDelayInSeconds();
            }
        }

        public virtual async Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Cron-Job gestartet");

            if (this.isExecutingOnInitialization)
            {
                await this.ExecuteScheduledJobTask();
            }

            this.ScheduleNextJob(cancellationToken);
        }

        public virtual Task StopAsync(CancellationToken cancellationToken)
        {
            this.timer?.Stop();
            this.logger.LogInformation("Cron-Job wurde gestoppt");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.timer?.Dispose();
                }

                this.disposedValue = true;
            }
        }

        protected void ScheduleNextJob(CancellationToken cancellationToken)
        {
            var delay = TimeSpan.FromSeconds(this.delayInSeconds);

            this.timer = new System.Timers.Timer(delay.TotalMilliseconds);
            this.timer.Elapsed += async (sender, args) =>
            {
                this.timer.Dispose();
                this.timer = null;

                if (!cancellationToken.IsCancellationRequested)
                {
                    await this.ExecuteScheduledJobTask();
                    this.ScheduleNextJob(cancellationToken);
                }
            };
            this.timer.Start();
        }

        private async Task ExecuteScheduledJobTask()
        {
            try
            {
                this.logger.LogInformation("Cron-Job-Anweisung wird ausgeführt");

                using (var scope = this.serviceProvider.CreateScope())
                {
                    var executer = (TScheduledJob)scope.ServiceProvider.GetRequiredService(typeof(TScheduledJob));
                    await executer.Execute();
                }

                this.logger.LogInformation("Cron-Job-Anweisung wurde erfolgreich ausgeführt");
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, "Cron-Job-Anweisung ist mit einem Fehler abgebrochen");
            }
        }
    }
}