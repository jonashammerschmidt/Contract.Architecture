using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
{
    internal class GegoennterKundeCreateTest : IGegoennterKundeCreate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool? GegoennterBoolean { get; set; }

        public DateTime? GegoennterDateTime { get; set; }

        public double? GegoennterDouble { get; set; }

        public Guid? GegoennterGuid { get; set; }

        public int? GegoennterInteger { get; set; }

        public Guid BesteBankId { get; set; }

        public static IGegoennterKundeCreate ForCreate()
        {
            return new GegoennterKundeCreateTest()
            {
                Id = GegoennterKundeTestValues.IdForCreate,
                Name = GegoennterKundeTestValues.NameForCreate,
                GegoennterName = GegoennterKundeTestValues.GegoennterNameForCreate,
                GegoennterBoolean = GegoennterKundeTestValues.GegoennterBooleanForCreate,
                GegoennterDateTime = GegoennterKundeTestValues.GegoennterDateTimeForCreate,
                GegoennterDouble = GegoennterKundeTestValues.GegoennterDoubleForCreate,
                GegoennterGuid = GegoennterKundeTestValues.GegoennterGuidForCreate,
                GegoennterInteger = GegoennterKundeTestValues.GegoennterIntegerForCreate,
                BesteBankId = GegoennterKundeTestValues.BesteBankIdForCreate,
            };
        }
    }
}