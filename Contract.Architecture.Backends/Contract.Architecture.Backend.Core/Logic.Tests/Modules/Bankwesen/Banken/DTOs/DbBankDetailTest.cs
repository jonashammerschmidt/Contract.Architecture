using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Logic.Tests.Modules.Kundenstamm.Kunden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Bankwesen.Banken
{
    internal class DbBankDetailTest : IDbBankDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Boolean { get; set; }

        public DateTime DateTime { get; set; }

        public double Double { get; set; }

        public Guid Guid { get; set; }

        public int Integer { get; set; }

        public IEnumerable<IDbKunde> Kunden { get; set; }

        public static IDbBankDetail Default()
        {
            return new DbBankDetailTest()
            {
                Id = BankTestValues.IdDefault,
                Name = BankTestValues.NameDefault,
                Boolean = BankTestValues.BooleanDefault,
                DateTime = BankTestValues.DateTimeDefault,
                Double = BankTestValues.DoubleDefault,
                Guid = BankTestValues.GuidDefault,
                Integer = BankTestValues.IntegerDefault,
                Kunden = new List<IDbKunde> { DbKundeTest.Default() },
            };
        }

        public static void AssertDefault(IDbBankDetail dbBankDetail)
        {
            Assert.AreEqual(BankTestValues.IdDefault, dbBankDetail.Id);
            Assert.AreEqual(BankTestValues.NameDefault, dbBankDetail.Name);
            Assert.AreEqual(BankTestValues.BooleanDefault, dbBankDetail.Boolean);
            Assert.AreEqual(BankTestValues.DateTimeDefault, dbBankDetail.DateTime);
            Assert.AreEqual(BankTestValues.DoubleDefault, dbBankDetail.Double);
            Assert.AreEqual(BankTestValues.GuidDefault, dbBankDetail.Guid);
            Assert.AreEqual(BankTestValues.IntegerDefault, dbBankDetail.Integer);
            DbKundeTest.AssertDefault(dbBankDetail.Kunden.ToArray()[0]);
        }
    }
}