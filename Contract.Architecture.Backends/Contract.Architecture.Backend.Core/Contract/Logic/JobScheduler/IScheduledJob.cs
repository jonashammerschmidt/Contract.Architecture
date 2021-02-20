using System.Threading.Tasks;

namespace Contract.Architecture.Backend.Core.Contract.Logic.JobScheduler
{
    public interface IScheduledJob
    {
        int GetDelayInSeconds();

        bool IsExecutingOnInitialization();

        Task Execute();
    }
}