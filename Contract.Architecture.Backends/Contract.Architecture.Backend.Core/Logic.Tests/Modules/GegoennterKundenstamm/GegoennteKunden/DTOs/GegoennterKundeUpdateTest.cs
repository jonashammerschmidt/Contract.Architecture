using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
{
    internal class GegoennterKundeUpdateTest : IGegoennterKundeUpdate
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

        public static IGegoennterKundeUpdate ForUpdate()
        {
            return new GegoennterKundeUpdateTest()
            {
                Id = GegoennterKundeTestValues.IdDefault,
                Name = GegoennterKundeTestValues.NameForUpdate,
                GegoennterName = GegoennterKundeTestValues.GegoennterNameForUpdate,
                GegoennterBoolean = GegoennterKundeTestValues.GegoennterBooleanForUpdate,
                GegoennterDateTime = GegoennterKundeTestValues.GegoennterDateTimeForUpdate,
                GegoennterDouble = GegoennterKundeTestValues.GegoennterDoubleForUpdate,
                GegoennterGuid = GegoennterKundeTestValues.GegoennterGuidForUpdate,
                GegoennterInteger = GegoennterKundeTestValues.GegoennterIntegerForUpdate,
                BesteBankId = GegoennterKundeTestValues.BesteBankIdForUpdate,
            };
        }
    }
}