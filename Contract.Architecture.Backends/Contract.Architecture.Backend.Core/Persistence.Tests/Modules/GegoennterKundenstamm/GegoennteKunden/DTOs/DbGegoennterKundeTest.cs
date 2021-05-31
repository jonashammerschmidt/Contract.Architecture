using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
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

        public static IDbGegoennterKunde DbDefault()
        {
            return new DbGegoennterKundeTest()
            {
                Id = GegoennterKundeTestValues.IdDbDefault,
                Name = GegoennterKundeTestValues.NameDbDefault,
                GegoennterName = GegoennterKundeTestValues.GegoennterNameDbDefault,
                GegoennterBoolean = GegoennterKundeTestValues.GegoennterBooleanDbDefault,
                GegoennterDateTime = GegoennterKundeTestValues.GegoennterDateTimeDbDefault,
                GegoennterDouble = GegoennterKundeTestValues.GegoennterDoubleDbDefault,
                GegoennterGuid = GegoennterKundeTestValues.GegoennterGuidDbDefault,
                GegoennterInteger = GegoennterKundeTestValues.GegoennterIntegerDbDefault,
                BesteBankId = GegoennterKundeTestValues.BesteBankIdDbDefault,
            };
        }

        public static IDbGegoennterKunde DbDefault2()
        {
            return new DbGegoennterKundeTest()
            {
                Id = GegoennterKundeTestValues.IdDbDefault2,
                Name = GegoennterKundeTestValues.NameDbDefault2,
                GegoennterName = GegoennterKundeTestValues.GegoennterNameDbDefault2,
                GegoennterBoolean = GegoennterKundeTestValues.GegoennterBooleanDbDefault2,
                GegoennterDateTime = GegoennterKundeTestValues.GegoennterDateTimeDbDefault2,
                GegoennterDouble = GegoennterKundeTestValues.GegoennterDoubleDbDefault2,
                GegoennterGuid = GegoennterKundeTestValues.GegoennterGuidDbDefault2,
                GegoennterInteger = GegoennterKundeTestValues.GegoennterIntegerDbDefault2,
                BesteBankId = GegoennterKundeTestValues.BesteBankIdDbDefault2,
            };
        }

        public static IDbGegoennterKunde ForCreate()
        {
            return new DbGegoennterKundeTest()
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

        public static IDbGegoennterKunde ForUpdate()
        {
            return new DbGegoennterKundeTest()
            {
                Id = GegoennterKundeTestValues.IdDbDefault,
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

        public static void AssertDbDefault(IDbGegoennterKunde dbGegoennterKunde)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDbDefault, dbGegoennterKunde.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameDbDefault, dbGegoennterKunde.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameDbDefault, dbGegoennterKunde.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanDbDefault, dbGegoennterKunde.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeDbDefault, dbGegoennterKunde.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleDbDefault, dbGegoennterKunde.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidDbDefault, dbGegoennterKunde.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerDbDefault, dbGegoennterKunde.GegoennterInteger);
            Assert.AreEqual(GegoennterKundeTestValues.BesteBankIdDbDefault, dbGegoennterKunde.BesteBankId);
        }

        public static void AssertDbDefault2(IDbGegoennterKunde dbGegoennterKunde)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDbDefault2, dbGegoennterKunde.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameDbDefault2, dbGegoennterKunde.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameDbDefault2, dbGegoennterKunde.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanDbDefault2, dbGegoennterKunde.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeDbDefault2, dbGegoennterKunde.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleDbDefault2, dbGegoennterKunde.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidDbDefault2, dbGegoennterKunde.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerDbDefault2, dbGegoennterKunde.GegoennterInteger);
            Assert.AreEqual(GegoennterKundeTestValues.BesteBankIdDbDefault2, dbGegoennterKunde.BesteBankId);
        }

        public static void AssertForCreate(IDbGegoennterKunde dbGegoennterKunde)
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

        public static void AssertForUpdate(IDbGegoennterKunde dbGegoennterKunde)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDbDefault, dbGegoennterKunde.Id);
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