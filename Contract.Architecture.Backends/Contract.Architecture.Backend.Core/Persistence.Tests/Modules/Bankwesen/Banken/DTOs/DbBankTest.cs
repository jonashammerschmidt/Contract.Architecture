using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.Bankwesen.Banken
{
    internal class DbBankTest : IDbBank
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Boolean { get; set; }

        public DateTime DateTime { get; set; }

        public double Double { get; set; }

        public Guid Guid { get; set; }

        public int Integer { get; set; }

        public static IDbBank DbDefault()
        {
            return new DbBankTest()
            {
                Id = BankTestValues.IdDbDefault,
                Name = BankTestValues.NameDbDefault,
                Boolean = BankTestValues.BooleanDbDefault,
                DateTime = BankTestValues.DateTimeDbDefault,
                Double = BankTestValues.DoubleDbDefault,
                Guid = BankTestValues.GuidDbDefault,
                Integer = BankTestValues.IntegerDbDefault,
            };
        }

        public static IDbBank DbDefault2()
        {
            return new DbBankTest()
            {
                Id = BankTestValues.IdDbDefault2,
                Name = BankTestValues.NameDbDefault2,
                Boolean = BankTestValues.BooleanDbDefault2,
                DateTime = BankTestValues.DateTimeDbDefault2,
                Double = BankTestValues.DoubleDbDefault2,
                Guid = BankTestValues.GuidDbDefault2,
                Integer = BankTestValues.IntegerDbDefault2,
            };
        }

        public static IDbBank ForCreate()
        {
            return new DbBankTest()
            {
                Id = BankTestValues.IdForCreate,
                Name = BankTestValues.NameForCreate,
                Boolean = BankTestValues.BooleanForCreate,
                DateTime = BankTestValues.DateTimeForCreate,
                Double = BankTestValues.DoubleForCreate,
                Guid = BankTestValues.GuidForCreate,
                Integer = BankTestValues.IntegerForCreate,
            };
        }

        public static IDbBank ForUpdate()
        {
            return new DbBankTest()
            {
                Id = BankTestValues.IdDbDefault,
                Name = BankTestValues.NameForUpdate,
                Boolean = BankTestValues.BooleanForUpdate,
                DateTime = BankTestValues.DateTimeForUpdate,
                Double = BankTestValues.DoubleForUpdate,
                Guid = BankTestValues.GuidForUpdate,
                Integer = BankTestValues.IntegerForUpdate,
            };
        }

        public static void AssertDbDefault(IDbBank dbBank)
        {
            Assert.AreEqual(BankTestValues.IdDbDefault, dbBank.Id);
            Assert.AreEqual(BankTestValues.NameDbDefault, dbBank.Name);
            Assert.AreEqual(BankTestValues.BooleanDbDefault, dbBank.Boolean);
            Assert.AreEqual(BankTestValues.DateTimeDbDefault, dbBank.DateTime);
            Assert.AreEqual(BankTestValues.DoubleDbDefault, dbBank.Double);
            Assert.AreEqual(BankTestValues.GuidDbDefault, dbBank.Guid);
            Assert.AreEqual(BankTestValues.IntegerDbDefault, dbBank.Integer);
        }

        public static void AssertDbDefault2(IDbBank dbBank)
        {
            Assert.AreEqual(BankTestValues.IdDbDefault2, dbBank.Id);
            Assert.AreEqual(BankTestValues.NameDbDefault2, dbBank.Name);
            Assert.AreEqual(BankTestValues.BooleanDbDefault2, dbBank.Boolean);
            Assert.AreEqual(BankTestValues.DateTimeDbDefault2, dbBank.DateTime);
            Assert.AreEqual(BankTestValues.DoubleDbDefault2, dbBank.Double);
            Assert.AreEqual(BankTestValues.GuidDbDefault2, dbBank.Guid);
            Assert.AreEqual(BankTestValues.IntegerDbDefault2, dbBank.Integer);
        }

        public static void AssertForCreate(IDbBank dbBank)
        {
            Assert.AreEqual(BankTestValues.IdForCreate, dbBank.Id);
            Assert.AreEqual(BankTestValues.NameForCreate, dbBank.Name);
            Assert.AreEqual(BankTestValues.BooleanForCreate, dbBank.Boolean);
            Assert.AreEqual(BankTestValues.DateTimeForCreate, dbBank.DateTime);
            Assert.AreEqual(BankTestValues.DoubleForCreate, dbBank.Double);
            Assert.AreEqual(BankTestValues.GuidForCreate, dbBank.Guid);
            Assert.AreEqual(BankTestValues.IntegerForCreate, dbBank.Integer);
        }

        public static void AssertForUpdate(IDbBank dbBank)
        {
            Assert.AreEqual(BankTestValues.IdDbDefault, dbBank.Id);
            Assert.AreEqual(BankTestValues.NameForUpdate, dbBank.Name);
            Assert.AreEqual(BankTestValues.BooleanForUpdate, dbBank.Boolean);
            Assert.AreEqual(BankTestValues.DateTimeForUpdate, dbBank.DateTime);
            Assert.AreEqual(BankTestValues.DoubleForUpdate, dbBank.Double);
            Assert.AreEqual(BankTestValues.GuidForUpdate, dbBank.Guid);
            Assert.AreEqual(BankTestValues.IntegerForUpdate, dbBank.Integer);
        }
    }
}