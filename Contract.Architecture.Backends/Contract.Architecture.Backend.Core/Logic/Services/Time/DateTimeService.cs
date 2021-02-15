using Contract.Architecture.Backend.Core.Contract.Logic.Services.Time;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Services.Time
{
    internal class DateTimeService : IDateTimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}