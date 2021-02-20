using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Time;
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