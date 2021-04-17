using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Persistence.Tests.Modules.Bankwesen.Banken;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.Kundenstamm.Kunden
{
    internal class DbKundeDetailTest : IDbKundeDetail
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool? Boolean { get; set; }

        public DateTime? DateTime { get; set; }

        public double? Double { get; set; }

        public Guid? Guid { get; set; }

        public int? Integer { get; set; }

        public IDbBank Bank { get; set; }

        public static void AssertDbDefault(IDbKundeDetail dbKundeDetail)
        {
            Assert.AreEqual(KundeTestValues.IdDbDefault, dbKundeDetail.Id);
            Assert.AreEqual(KundeTestValues.NameDbDefault, dbKundeDetail.Name);
            Assert.AreEqual(KundeTestValues.BooleanDbDefault, dbKundeDetail.Boolean);
            Assert.AreEqual(KundeTestValues.DateTimeDbDefault, dbKundeDetail.DateTime);
            Assert.AreEqual(KundeTestValues.DoubleDbDefault, dbKundeDetail.Double);
            Assert.AreEqual(KundeTestValues.GuidDbDefault, dbKundeDetail.Guid);
            Assert.AreEqual(KundeTestValues.IntegerDbDefault, dbKundeDetail.Integer);
            DbBankTest.AssertDbDefault(dbKundeDetail.Bank);
        }
    }
}