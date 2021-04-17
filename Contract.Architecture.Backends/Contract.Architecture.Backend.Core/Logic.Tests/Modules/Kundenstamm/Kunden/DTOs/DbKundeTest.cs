using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Kundenstamm.Kunden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Kundenstamm.Kunden
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

        public static IDbKunde Default()
        {
            return new DbKundeTest()
            {
                Id = KundeTestValues.IdDefault,
                Name = KundeTestValues.NameDefault,
                Boolean = KundeTestValues.BooleanDefault,
                DateTime = KundeTestValues.DateTimeDefault,
                Double = KundeTestValues.DoubleDefault,
                Guid = KundeTestValues.GuidDefault,
                Integer = KundeTestValues.IntegerDefault,
                BankId = KundeTestValues.BankIdDefault,
            };
        }

        public static IDbKunde ForUpdate()
        {
            return new DbKundeTest()
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

        public static void AssertDefault(IDbKunde dbKunde)
        {
            Assert.AreEqual(KundeTestValues.IdDefault, dbKunde.Id);
            Assert.AreEqual(KundeTestValues.NameDefault, dbKunde.Name);
            Assert.AreEqual(KundeTestValues.BooleanDefault, dbKunde.Boolean);
            Assert.AreEqual(KundeTestValues.DateTimeDefault, dbKunde.DateTime);
            Assert.AreEqual(KundeTestValues.DoubleDefault, dbKunde.Double);
            Assert.AreEqual(KundeTestValues.GuidDefault, dbKunde.Guid);
            Assert.AreEqual(KundeTestValues.IntegerDefault, dbKunde.Integer);
            Assert.AreEqual(KundeTestValues.BankIdDefault, dbKunde.BankId);
        }

        public static void AssertCreated(IDbKunde dbKunde)
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

        public static void AssertUpdated(IDbKunde dbKunde)
        {
            Assert.AreEqual(KundeTestValues.IdDefault, dbKunde.Id);
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