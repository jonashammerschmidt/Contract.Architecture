using Contract.Architecture.Backend.Core.Contract.Logic.Services.Time;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tools.Time
{
    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}