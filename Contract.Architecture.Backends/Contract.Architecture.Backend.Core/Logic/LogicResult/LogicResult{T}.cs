using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;

namespace Contract.Architecture.Backend.Core.Logic.LogicResults
{
    internal class LogicResult<T> : ILogicResult<T>
    {
        public LogicResultState State { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }

        public bool IsSuccessful
        {
            get
            {
                return this.State == LogicResultState.Ok;
            }
        }

        public static LogicResult<T> Ok()
        {
            return new LogicResult<T>()
            {
                State = LogicResultState.Ok
            };
        }

        public static LogicResult<T> Ok(T result)
        {
            return new LogicResult<T>()
            {
                State = LogicResultState.Ok,
                Data = result
            };
        }

        public static LogicResult<T> BadRequest()
        {
            return new LogicResult<T>()
            {
                State = LogicResultState.BadRequest
            };
        }

        public static LogicResult<T> BadRequest(string message)
        {
            return new LogicResult<T>()
            {
                State = LogicResultState.BadRequest,
                Message = message
            };
        }

        public static LogicResult<T> Forbidden()
        {
            return new LogicResult<T>()
            {
                State = LogicResultState.Forbidden
            };
        }

        public static LogicResult<T> Forbidden(string message)
        {
            return new LogicResult<T>()
            {
                State = LogicResultState.Forbidden,
                Message = message
            };
        }

        public static LogicResult<T> NotFound()
        {
            return new LogicResult<T>()
            {
                State = LogicResultState.NotFound
            };
        }

        public static LogicResult<T> NotFound(string message)
        {
            return new LogicResult<T>()
            {
                State = LogicResultState.NotFound,
                Message = message
            };
        }

        public static LogicResult<T> Conflict()
        {
            return new LogicResult<T>()
            {
                State = LogicResultState.Conflict
            };
        }

        public static LogicResult<T> Conflict(string message)
        {
            return new LogicResult<T>()
            {
                State = LogicResultState.Conflict,
                Message = message
            };
        }

        public static LogicResult<T> Forward(ILogicResult result)
        {
            return new LogicResult<T>()
            {
                State = result.State,
                Message = result.Message
            };
        }

        public static LogicResult<T> Forward<T2>(ILogicResult<T2> result)
        {
            return new LogicResult<T>()
            {
                State = result.State,
                Message = result.Message
            };
        }
    }
}