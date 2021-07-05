using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoenntesBankwesen.GegoennteBanken;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
{
    internal class DbGegoennterKundeDetailTest : IDbGegoennterKundeDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool? GegoennterBoolean { get; set; }

        public DateTime? GegoennterDateTime { get; set; }

        public double? GegoennterDouble { get; set; }

        public Guid? GegoennterGuid { get; set; }

        public int? GegoennterInteger { get; set; }

        public IDbGegoennteBank BesteBank { get; set; }

        public static void AssertDbDefault(IDbGegoennterKundeDetail dbGegoennterKundeDetail)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDbDefault, dbGegoennterKundeDetail.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameDbDefault, dbGegoennterKundeDetail.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameDbDefault, dbGegoennterKundeDetail.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanDbDefault, dbGegoennterKundeDetail.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeDbDefault, dbGegoennterKundeDetail.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleDbDefault, dbGegoennterKundeDetail.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidDbDefault, dbGegoennterKundeDetail.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerDbDefault, dbGegoennterKundeDetail.GegoennterInteger);
            DbGegoennteBankTest.AssertDbDefault(dbGegoennterKundeDetail.BesteBank);
        }

        public static void AssertDbDefault2(IDbGegoennterKundeDetail dbGegoennterKundeDetail)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDbDefault2, dbGegoennterKundeDetail.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameDbDefault2, dbGegoennterKundeDetail.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameDbDefault2, dbGegoennterKundeDetail.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanDbDefault2, dbGegoennterKundeDetail.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeDbDefault2, dbGegoennterKundeDetail.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleDbDefault2, dbGegoennterKundeDetail.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidDbDefault2, dbGegoennterKundeDetail.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerDbDefault2, dbGegoennterKundeDetail.GegoennterInteger);
            DbGegoennteBankTest.AssertDbDefault2(dbGegoennterKundeDetail.BesteBank);
        }
    }
}