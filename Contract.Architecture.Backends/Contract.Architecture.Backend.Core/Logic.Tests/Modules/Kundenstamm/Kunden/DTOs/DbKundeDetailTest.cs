using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Logic.Tests.Modules.Bankwesen.Banken;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Kundenstamm.Kunden
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

        public static IDbKundeDetail Default()
        {
            return new DbKundeDetailTest()
            {
                Id = KundeTestValues.IdDefault,
                Name = KundeTestValues.NameDefault,
                Boolean = KundeTestValues.BooleanDefault,
                DateTime = KundeTestValues.DateTimeDefault,
                Double = KundeTestValues.DoubleDefault,
                Guid = KundeTestValues.GuidDefault,
                Integer = KundeTestValues.IntegerDefault,
                Bank = DbBankTest.Default(),
            };
        }

        public static void AssertDefault(IDbKundeDetail dbKundeDetail)
        {
            Assert.AreEqual(KundeTestValues.IdDefault, dbKundeDetail.Id);
            Assert.AreEqual(KundeTestValues.NameDefault, dbKundeDetail.Name);
            Assert.AreEqual(KundeTestValues.BooleanDefault, dbKundeDetail.Boolean);
            Assert.AreEqual(KundeTestValues.DateTimeDefault, dbKundeDetail.DateTime);
            Assert.AreEqual(KundeTestValues.DoubleDefault, dbKundeDetail.Double);
            Assert.AreEqual(KundeTestValues.GuidDefault, dbKundeDetail.Guid);
            Assert.AreEqual(KundeTestValues.IntegerDefault, dbKundeDetail.Integer);
            DbBankTest.AssertDefault(dbKundeDetail.Bank);
        }
    }
}