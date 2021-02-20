using System;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Tools.Time
{
    public interface IDateTimeProvider
    {
        DateTime Now();
    }
}