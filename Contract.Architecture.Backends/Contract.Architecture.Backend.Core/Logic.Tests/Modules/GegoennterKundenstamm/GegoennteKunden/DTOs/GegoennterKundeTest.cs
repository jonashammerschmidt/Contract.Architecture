using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
{
    internal class GegoennterKundeTest : IGegoennterKunde
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

        public static IGegoennterKunde Default()
        {
            return new GegoennterKundeTest()
            {
                Id = GegoennterKundeTestValues.IdDefault,
                Name = GegoennterKundeTestValues.NameDefault,
                GegoennterName = GegoennterKundeTestValues.GegoennterNameDefault,
                GegoennterBoolean = GegoennterKundeTestValues.GegoennterBooleanDefault,
                GegoennterDateTime = GegoennterKundeTestValues.GegoennterDateTimeDefault,
                GegoennterDouble = GegoennterKundeTestValues.GegoennterDoubleDefault,
                GegoennterGuid = GegoennterKundeTestValues.GegoennterGuidDefault,
                GegoennterInteger = GegoennterKundeTestValues.GegoennterIntegerDefault,
                BesteBankId = GegoennterKundeTestValues.BesteBankIdDefault,
            };
        }

        public static IGegoennterKunde Default2()
        {
            return new GegoennterKundeTest()
            {
                Id = GegoennterKundeTestValues.IdDefault2,
                Name = GegoennterKundeTestValues.NameDefault2,
                GegoennterName = GegoennterKundeTestValues.GegoennterNameDefault2,
                GegoennterBoolean = GegoennterKundeTestValues.GegoennterBooleanDefault2,
                GegoennterDateTime = GegoennterKundeTestValues.GegoennterDateTimeDefault2,
                GegoennterDouble = GegoennterKundeTestValues.GegoennterDoubleDefault2,
                GegoennterGuid = GegoennterKundeTestValues.GegoennterGuidDefault2,
                GegoennterInteger = GegoennterKundeTestValues.GegoennterIntegerDefault2,
                BesteBankId = GegoennterKundeTestValues.BesteBankIdDefault2,
            };
        }

        public static void AssertDefault(IGegoennterKunde gegoennterKunde)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDefault, gegoennterKunde.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameDefault, gegoennterKunde.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameDefault, gegoennterKunde.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanDefault, gegoennterKunde.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeDefault, gegoennterKunde.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleDefault, gegoennterKunde.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidDefault, gegoennterKunde.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerDefault, gegoennterKunde.GegoennterInteger);
            Assert.AreEqual(GegoennterKundeTestValues.BesteBankIdDefault, gegoennterKunde.BesteBankId);
        }

        public static void AssertDefault2(IGegoennterKunde gegoennterKunde)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDefault2, gegoennterKunde.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameDefault2, gegoennterKunde.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameDefault2, gegoennterKunde.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanDefault2, gegoennterKunde.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeDefault2, gegoennterKunde.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleDefault2, gegoennterKunde.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidDefault2, gegoennterKunde.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerDefault2, gegoennterKunde.GegoennterInteger);
            Assert.AreEqual(GegoennterKundeTestValues.BesteBankIdDefault2, gegoennterKunde.BesteBankId);
        }
    }
}