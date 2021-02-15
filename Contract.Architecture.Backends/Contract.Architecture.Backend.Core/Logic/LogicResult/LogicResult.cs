using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;

namespace Contract.Architecture.Backend.Core.Logic.LogicResults
{
    internal class LogicResult : ILogicResult
    {
        public LogicResultState State { get; set; }

        public string Message { get; set; }

        public bool IsSuccessful
        {
            get
            {
                return this.State == LogicResultState.Ok;
            }
        }

        public static LogicResult Ok()
        {
            return new LogicResult()
            {
                State = LogicResultState.Ok
            };
        }

        public static LogicResult BadRequest()
        {
            return new LogicResult()
            {
                State = LogicResultState.BadRequest
            };
        }

        public static LogicResult BadRequest(string message)
        {
            return new LogicResult()
            {
                State = LogicResultState.BadRequest,
                Message = message
            };
        }

        public static LogicResult Forbidden()
        {
            return new LogicResult()
            {
                State = LogicResultState.Forbidden
            };
        }

        public static LogicResult NotFound()
        {
            return new LogicResult()
            {
                State = LogicResultState.NotFound
            };
        }

        public static LogicResult NotFound(string message)
        {
            return new LogicResult()
            {
                State = LogicResultState.NotFound,
                Message = message
            };
        }

        public static LogicResult Conflict()
        {
            return new LogicResult()
            {
                State = LogicResultState.Conflict
            };
        }

        public static LogicResult Conflict(string message)
        {
            return new LogicResult()
            {
                State = LogicResultState.Conflict,
                Message = message
            };
        }

        public static LogicResult Forward(LogicResult result)
        {
            return new LogicResult()
            {
                State = result.State,
                Message = result.Message
            };
        }

        public static LogicResult Forward<T>(ILogicResult<T> result)
        {
            return new LogicResult()
            {
                State = result.State,
                Message = result.Message
            };
        }
    }
}