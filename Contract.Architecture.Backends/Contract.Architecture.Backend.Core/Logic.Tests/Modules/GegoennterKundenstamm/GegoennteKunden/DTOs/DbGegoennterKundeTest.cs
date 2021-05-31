using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
{
    internal class DbGegoennterKundeTest : IDbGegoennterKunde
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

        public static IDbGegoennterKunde Default()
        {
            return new DbGegoennterKundeTest()
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

        public static IDbGegoennterKunde Default2()
        {
            return new DbGegoennterKundeTest()
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

        public static IDbGegoennterKunde ForUpdate()
        {
            return new DbGegoennterKundeTest()
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

        public static void AssertDefault(IDbGegoennterKunde dbGegoennterKunde)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDefault, dbGegoennterKunde.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameDefault, dbGegoennterKunde.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameDefault, dbGegoennterKunde.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanDefault, dbGegoennterKunde.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeDefault, dbGegoennterKunde.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleDefault, dbGegoennterKunde.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidDefault, dbGegoennterKunde.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerDefault, dbGegoennterKunde.GegoennterInteger);
            Assert.AreEqual(GegoennterKundeTestValues.BesteBankIdDefault, dbGegoennterKunde.BesteBankId);
        }

        public static void AssertDefault2(IDbGegoennterKunde dbGegoennterKunde)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDefault2, dbGegoennterKunde.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameDefault2, dbGegoennterKunde.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameDefault2, dbGegoennterKunde.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanDefault2, dbGegoennterKunde.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeDefault2, dbGegoennterKunde.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleDefault2, dbGegoennterKunde.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidDefault2, dbGegoennterKunde.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerDefault2, dbGegoennterKunde.GegoennterInteger);
            Assert.AreEqual(GegoennterKundeTestValues.BesteBankIdDefault2, dbGegoennterKunde.BesteBankId);
        }

        public static void AssertCreated(IDbGegoennterKunde dbGegoennterKunde)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdForCreate, dbGegoennterKunde.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameForCreate, dbGegoennterKunde.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameForCreate, dbGegoennterKunde.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanForCreate, dbGegoennterKunde.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeForCreate, dbGegoennterKunde.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleForCreate, dbGegoennterKunde.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidForCreate, dbGegoennterKunde.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerForCreate, dbGegoennterKunde.GegoennterInteger);
            Assert.AreEqual(GegoennterKundeTestValues.BesteBankIdForCreate, dbGegoennterKunde.BesteBankId);
        }

        public static void AssertUpdated(IDbGegoennterKunde dbGegoennterKunde)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDefault, dbGegoennterKunde.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameForUpdate, dbGegoennterKunde.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameForUpdate, dbGegoennterKunde.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanForUpdate, dbGegoennterKunde.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeForUpdate, dbGegoennterKunde.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleForUpdate, dbGegoennterKunde.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidForUpdate, dbGegoennterKunde.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerForUpdate, dbGegoennterKunde.GegoennterInteger);
            Assert.AreEqual(GegoennterKundeTestValues.BesteBankIdForUpdate, dbGegoennterKunde.BesteBankId);
        }
    }
}