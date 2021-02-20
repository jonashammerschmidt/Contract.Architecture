using Contract.Architecture.Backend.Core.Contract.Logic.Services.ScheduledJob;
using Microsoft.Extensions.DependencyInjection;

namespace Contract.Architecture.Backend.Core.Logic.Services.ScheduledJobs
{
    public static class ScheduledJobExtension
    {
        public static IServiceCollection AddScheduledJob<TScheduledJob>(this IServiceCollection services)
            where TScheduledJob : IScheduledJob
        {
            services.AddScoped(typeof(TScheduledJob));
            services.AddHostedService<JobScheduler<TScheduledJob>>();

            return services;
        }
    }
}