using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Bankwesen.Banken;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Bankwesen.Banken
{
    internal class BankTest : IBank
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Boolean { get; set; }

        public DateTime DateTime { get; set; }

        public double Double { get; set; }

        public Guid Guid { get; set; }

        public int Integer { get; set; }

        public static IBank Default()
        {
            return new BankTest()
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

        public static void AssertDefault(IBank bank)
        {
            Assert.AreEqual(BankTestValues.IdDefault, bank.Id);
            Assert.AreEqual(BankTestValues.NameDefault, bank.Name);
            Assert.AreEqual(BankTestValues.BooleanDefault, bank.Boolean);
            Assert.AreEqual(BankTestValues.DateTimeDefault, bank.DateTime);
            Assert.AreEqual(BankTestValues.DoubleDefault, bank.Double);
            Assert.AreEqual(BankTestValues.GuidDefault, bank.Guid);
            Assert.AreEqual(BankTestValues.IntegerDefault, bank.Integer);
        }
    }
}