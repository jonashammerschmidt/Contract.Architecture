namespace Contract.Architecture.Backend.Core.Contract.Logic.LogicResults
{
    public interface ILogicResult<T>
    {
        LogicResultState State { get; set; }

        T Data { get; set; }

        string Message { get; set; }

        bool IsSuccessful { get; }
    }
}