using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Logic.Tests.Modules.Bankwesen.Banken;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Kundenstamm.Kunden
{
    internal class KundeDetailTest : IKundeDetail
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool? Boolean { get; set; }

        public DateTime? DateTime { get; set; }

        public double? Double { get; set; }

        public Guid? Guid { get; set; }

        public int? Integer { get; set; }

        public IBank Bank { get; set; }

        public static IKundeDetail Default()
        {
            return new KundeDetailTest()
            {
                Id = KundeTestValues.IdDefault,
                Name = KundeTestValues.NameDefault,
                Boolean = KundeTestValues.BooleanDefault,
                DateTime = KundeTestValues.DateTimeDefault,
                Double = KundeTestValues.DoubleDefault,
                Guid = KundeTestValues.GuidDefault,
                Integer = KundeTestValues.IntegerDefault,
            };
        }

        public static void AssertDefault(IKundeDetail kundeDetail)
        {
            Assert.AreEqual(KundeTestValues.IdDefault, kundeDetail.Id);
            Assert.AreEqual(KundeTestValues.NameDefault, kundeDetail.Name);
            Assert.AreEqual(KundeTestValues.BooleanDefault, kundeDetail.Boolean);
            Assert.AreEqual(KundeTestValues.DateTimeDefault, kundeDetail.DateTime);
            Assert.AreEqual(KundeTestValues.DoubleDefault, kundeDetail.Double);
            Assert.AreEqual(KundeTestValues.GuidDefault, kundeDetail.Guid);
            Assert.AreEqual(KundeTestValues.IntegerDefault, kundeDetail.Integer);
            BankTest.AssertDefault(kundeDetail.Bank);
        }
    }
}