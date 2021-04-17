using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Kundenstamm.Kunden;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Kundenstamm.Kunden
{
    internal class KundeCreateTest : IKundeCreate
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool? Boolean { get; set; }

        public DateTime? DateTime { get; set; }

        public double? Double { get; set; }

        public Guid? Guid { get; set; }

        public int? Integer { get; set; }

        public Guid BankId { get; set; }

        public static IKundeCreate ForCreate()
        {
            return new KundeCreateTest()
            {
                Id = KundeTestValues.IdForCreate,
                Name = KundeTestValues.NameForCreate,
                Boolean = KundeTestValues.BooleanForCreate,
                DateTime = KundeTestValues.DateTimeForCreate,
                Double = KundeTestValues.DoubleForCreate,
                Guid = KundeTestValues.GuidForCreate,
                Integer = KundeTestValues.IntegerForCreate,
                BankId = KundeTestValues.BankIdForCreate,
            };
        }
    }
}