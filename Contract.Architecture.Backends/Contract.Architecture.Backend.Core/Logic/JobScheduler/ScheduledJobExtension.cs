using Contract.Architecture.Backend.Core.Contract.Logic.JobScheduler;
using Microsoft.Extensions.DependencyInjection;

namespace Contract.Architecture.Backend.Core.Logic.JobSchedulers
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