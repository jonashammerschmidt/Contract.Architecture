using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Kundenstamm.Kunden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.Kundenstamm.Kunden
{
    internal class DbKundeTest : IDbKunde
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool? Boolean { get; set; }

        public DateTime? DateTime { get; set; }

        public double? Double { get; set; }

        public Guid? Guid { get; set; }

        public int? Integer { get; set; }

        public Guid BankId { get; set; }

        public static IDbKunde DbDefault()
        {
            return new DbKundeTest()
            {
                Id = KundeTestValues.IdDbDefault,
                Name = KundeTestValues.NameDbDefault,
                Boolean = KundeTestValues.BooleanDbDefault,
                DateTime = KundeTestValues.DateTimeDbDefault,
                Double = KundeTestValues.DoubleDbDefault,
                Guid = KundeTestValues.GuidDbDefault,
                Integer = KundeTestValues.IntegerDbDefault,
                BankId = KundeTestValues.BankIdDbDefault,
            };
        }

        public static IDbKunde DbDefault2()
        {
            return new DbKundeTest()
            {
                Id = KundeTestValues.IdDbDefault2,
                Name = KundeTestValues.NameDbDefault2,
                Boolean = KundeTestValues.BooleanDbDefault2,
                DateTime = KundeTestValues.DateTimeDbDefault2,
                Double = KundeTestValues.DoubleDbDefault2,
                Guid = KundeTestValues.GuidDbDefault2,
                Integer = KundeTestValues.IntegerDbDefault2,
                BankId = KundeTestValues.BankIdDbDefault2,
            };
        }

        public static IDbKunde ForCreate()
        {
            return new DbKundeTest()
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

        public static IDbKunde ForUpdate()
        {
            return new DbKundeTest()
            {
                Id = KundeTestValues.IdDbDefault,
                Name = KundeTestValues.NameForUpdate,
                Boolean = KundeTestValues.BooleanForUpdate,
                DateTime = KundeTestValues.DateTimeForUpdate,
                Double = KundeTestValues.DoubleForUpdate,
                Guid = KundeTestValues.GuidForUpdate,
                Integer = KundeTestValues.IntegerForUpdate,
                BankId = KundeTestValues.BankIdForUpdate,
            };
        }

        public static void AssertDbDefault(IDbKunde dbKunde)
        {
            Assert.AreEqual(KundeTestValues.IdDbDefault, dbKunde.Id);
            Assert.AreEqual(KundeTestValues.NameDbDefault, dbKunde.Name);
            Assert.AreEqual(KundeTestValues.BooleanDbDefault, dbKunde.Boolean);
            Assert.AreEqual(KundeTestValues.DateTimeDbDefault, dbKunde.DateTime);
            Assert.AreEqual(KundeTestValues.DoubleDbDefault, dbKunde.Double);
            Assert.AreEqual(KundeTestValues.GuidDbDefault, dbKunde.Guid);
            Assert.AreEqual(KundeTestValues.IntegerDbDefault, dbKunde.Integer);
            Assert.AreEqual(KundeTestValues.BankIdDbDefault, dbKunde.BankId);
        }

        public static void AssertDbDefault2(IDbKunde dbKunde)
        {
            Assert.AreEqual(KundeTestValues.IdDbDefault2, dbKunde.Id);
            Assert.AreEqual(KundeTestValues.NameDbDefault2, dbKunde.Name);
            Assert.AreEqual(KundeTestValues.BooleanDbDefault2, dbKunde.Boolean);
            Assert.AreEqual(KundeTestValues.DateTimeDbDefault2, dbKunde.DateTime);
            Assert.AreEqual(KundeTestValues.DoubleDbDefault2, dbKunde.Double);
            Assert.AreEqual(KundeTestValues.GuidDbDefault2, dbKunde.Guid);
            Assert.AreEqual(KundeTestValues.IntegerDbDefault2, dbKunde.Integer);
            Assert.AreEqual(KundeTestValues.BankIdDbDefault2, dbKunde.BankId);
        }

        public static void AssertForCreate(IDbKunde dbKunde)
        {
            Assert.AreEqual(KundeTestValues.IdForCreate, dbKunde.Id);
            Assert.AreEqual(KundeTestValues.NameForCreate, dbKunde.Name);
            Assert.AreEqual(KundeTestValues.BooleanForCreate, dbKunde.Boolean);
            Assert.AreEqual(KundeTestValues.DateTimeForCreate, dbKunde.DateTime);
            Assert.AreEqual(KundeTestValues.DoubleForCreate, dbKunde.Double);
            Assert.AreEqual(KundeTestValues.GuidForCreate, dbKunde.Guid);
            Assert.AreEqual(KundeTestValues.IntegerForCreate, dbKunde.Integer);
            Assert.AreEqual(KundeTestValues.BankIdForCreate, dbKunde.BankId);
        }

        public static void AssertForUpdate(IDbKunde dbKunde)
        {
            Assert.AreEqual(KundeTestValues.IdDbDefault, dbKunde.Id);
            Assert.AreEqual(KundeTestValues.NameForUpdate, dbKunde.Name);
            Assert.AreEqual(KundeTestValues.BooleanForUpdate, dbKunde.Boolean);
            Assert.AreEqual(KundeTestValues.DateTimeForUpdate, dbKunde.DateTime);
            Assert.AreEqual(KundeTestValues.DoubleForUpdate, dbKunde.Double);
            Assert.AreEqual(KundeTestValues.GuidForUpdate, dbKunde.Guid);
            Assert.AreEqual(KundeTestValues.IntegerForUpdate, dbKunde.Integer);
            Assert.AreEqual(KundeTestValues.BankIdForUpdate, dbKunde.BankId);
        }
    }
}