using System.Threading.Tasks;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Services.ScheduledJob
{
    public interface IScheduledJob
    {
        int GetDelayInSeconds();

        bool IsExecutingOnInitialization();

        Task Execute();
    }
}