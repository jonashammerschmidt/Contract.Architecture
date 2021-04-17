using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Persistence.Tests.Modules.Kundenstamm.Kunden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.Bankwesen.Banken
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

        public static void AssertDbDefault(IDbBankDetail dbBankDetail)
        {
            Assert.AreEqual(BankTestValues.IdDbDefault, dbBankDetail.Id);
            Assert.AreEqual(BankTestValues.NameDbDefault, dbBankDetail.Name);
            Assert.AreEqual(BankTestValues.BooleanDbDefault, dbBankDetail.Boolean);
            Assert.AreEqual(BankTestValues.DateTimeDbDefault, dbBankDetail.DateTime);
            Assert.AreEqual(BankTestValues.DoubleDbDefault, dbBankDetail.Double);
            Assert.AreEqual(BankTestValues.GuidDbDefault, dbBankDetail.Guid);
            Assert.AreEqual(BankTestValues.IntegerDbDefault, dbBankDetail.Integer);
            DbKundeTest.AssertDbDefault(dbBankDetail.Kunden.ToArray()[0]);
        }
    }
}