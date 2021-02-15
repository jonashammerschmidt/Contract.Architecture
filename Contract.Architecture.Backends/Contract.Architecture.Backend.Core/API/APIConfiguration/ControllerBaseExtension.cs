using Contract.Architecture.Backend.Core.Contract.Logic.LogicResults;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Contract.Architecture.Backend.Core.API
{
    public static class ControllerBaseExtension
    {
        public static ActionResult FromLogicResult(this ControllerBase controller, ILogicResult result)
        {
            switch (result.State)
            {
                case LogicResultState.Ok:
                    return controller.Ok();

                case LogicResultState.BadRequest:
                    return controller.BadRequest(result.Message);

                case LogicResultState.Forbidden:
                    return controller.Forbid(result.Message);

                case LogicResultState.NotFound:
                    return controller.NotFound(result.Message);

                case LogicResultState.Conflict:
                    return controller.Conflict(result.Message);

                default:
                    throw new Exception("An unhandled result has occurred as a result of a service call.");
            }
        }

        public static ActionResult FromLogicResult<T>(this ControllerBase controller, ILogicResult<T> result)
        {
            switch (result.State)
            {
                case LogicResultState.Ok:
                    return controller.Ok(result.Data);

                case LogicResultState.BadRequest:
                    return controller.BadRequest(result.Message);

                case LogicResultState.Forbidden:
                    return controller.Forbid(result.Message);

                case LogicResultState.NotFound:
                    return controller.NotFound(result.Message);

                case LogicResultState.Conflict:
                    return controller.Conflict(result.Message);

                default:
                    throw new Exception("An unhandled result has occurred as a result of a service call.");
            }
        }
    }
}