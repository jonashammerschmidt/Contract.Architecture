using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Kundenstamm.Kunden;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Kundenstamm.Kunden
{
    internal class KundeUpdateTest : IKundeUpdate
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool? Boolean { get; set; }

        public DateTime? DateTime { get; set; }

        public double? Double { get; set; }

        public Guid? Guid { get; set; }

        public int? Integer { get; set; }

        public Guid BankId { get; set; }

        public static IKundeUpdate ForUpdate()
        {
            return new KundeUpdateTest()
            {
                Id = KundeTestValues.IdDefault,
                Name = KundeTestValues.NameForUpdate,
                Boolean = KundeTestValues.BooleanForUpdate,
                DateTime = KundeTestValues.DateTimeForUpdate,
                Double = KundeTestValues.DoubleForUpdate,
                Guid = KundeTestValues.GuidForUpdate,
                Integer = KundeTestValues.IntegerForUpdate,
                BankId = KundeTestValues.BankIdForUpdate,
            };
        }
    }
}