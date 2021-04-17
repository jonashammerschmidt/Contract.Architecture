using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Logic.Tests.Modules.Kundenstamm.Kunden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Bankwesen.Banken
{
    internal class BankDetailTest : IBankDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Boolean { get; set; }

        public DateTime DateTime { get; set; }

        public double Double { get; set; }

        public Guid Guid { get; set; }

        public int Integer { get; set; }

        public IEnumerable<IKunde> Kunden { get; set; }

        public static IBankDetail Default()
        {
            return new BankDetailTest()
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

        public static void AssertDefault(IBankDetail bankDetail)
        {
            Assert.AreEqual(BankTestValues.IdDefault, bankDetail.Id);
            Assert.AreEqual(BankTestValues.NameDefault, bankDetail.Name);
            Assert.AreEqual(BankTestValues.BooleanDefault, bankDetail.Boolean);
            Assert.AreEqual(BankTestValues.DateTimeDefault, bankDetail.DateTime);
            Assert.AreEqual(BankTestValues.DoubleDefault, bankDetail.Double);
            Assert.AreEqual(BankTestValues.GuidDefault, bankDetail.Guid);
            Assert.AreEqual(BankTestValues.IntegerDefault, bankDetail.Integer);
            KundeTest.AssertDefault(bankDetail.Kunden.ToArray()[0]);
        }
    }
}