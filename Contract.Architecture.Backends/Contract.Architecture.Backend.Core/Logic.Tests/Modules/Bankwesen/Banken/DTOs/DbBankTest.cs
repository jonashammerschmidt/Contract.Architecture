using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Bankwesen.Banken
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

        public static IDbBank Default()
        {
            return new DbBankTest()
            {
                Id = BankTestValues.IdDefault,
                Name = BankTestValues.NameDefault,
                Boolean = BankTestValues.BooleanDefault,
                DateTime = BankTestValues.DateTimeDefault,
                Double = BankTestValues.DoubleDefault,
                Guid = BankTestValues.GuidDefault,
                Integer = BankTestValues.IntegerDefault,
            };
        }

        public static IDbBank ForUpdate()
        {
            return new DbBankTest()
            {
                Id = BankTestValues.IdDefault,
                Name = BankTestValues.NameForUpdate,
                Boolean = BankTestValues.BooleanForUpdate,
                DateTime = BankTestValues.DateTimeForUpdate,
                Double = BankTestValues.DoubleForUpdate,
                Guid = BankTestValues.GuidForUpdate,
                Integer = BankTestValues.IntegerForUpdate,
            };
        }

        public static void AssertDefault(IDbBank dbBank)
        {
            Assert.AreEqual(BankTestValues.IdDefault, dbBank.Id);
            Assert.AreEqual(BankTestValues.NameDefault, dbBank.Name);
            Assert.AreEqual(BankTestValues.BooleanDefault, dbBank.Boolean);
            Assert.AreEqual(BankTestValues.DateTimeDefault, dbBank.DateTime);
            Assert.AreEqual(BankTestValues.DoubleDefault, dbBank.Double);
            Assert.AreEqual(BankTestValues.GuidDefault, dbBank.Guid);
            Assert.AreEqual(BankTestValues.IntegerDefault, dbBank.Integer);
        }

        public static void AssertCreated(IDbBank dbBank)
        {
            Assert.AreEqual(BankTestValues.IdForCreate, dbBank.Id);
            Assert.AreEqual(BankTestValues.NameForCreate, dbBank.Name);
            Assert.AreEqual(BankTestValues.BooleanForCreate, dbBank.Boolean);
            Assert.AreEqual(BankTestValues.DateTimeForCreate, dbBank.DateTime);
            Assert.AreEqual(BankTestValues.DoubleForCreate, dbBank.Double);
            Assert.AreEqual(BankTestValues.GuidForCreate, dbBank.Guid);
            Assert.AreEqual(BankTestValues.IntegerForCreate, dbBank.Integer);
        }

        public static void AssertUpdated(IDbBank dbBank)
        {
            Assert.AreEqual(BankTestValues.IdDefault, dbBank.Id);
            Assert.AreEqual(BankTestValues.NameForUpdate, dbBank.Name);
            Assert.AreEqual(BankTestValues.BooleanForUpdate, dbBank.Boolean);
            Assert.AreEqual(BankTestValues.DateTimeForUpdate, dbBank.DateTime);
            Assert.AreEqual(BankTestValues.DoubleForUpdate, dbBank.Double);
            Assert.AreEqual(BankTestValues.GuidForUpdate, dbBank.Guid);
            Assert.AreEqual(BankTestValues.IntegerForUpdate, dbBank.Integer);
        }
    }
}