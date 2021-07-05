using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoenntesBankwesen.GegoennteBanken;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
{
    internal class DbGegoennterKundeListItemTest : IDbGegoennterKundeListItem
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

        public static void AssertDbDefault(IDbGegoennterKundeListItem dbGegoennterKundeListItem)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDbDefault, dbGegoennterKundeListItem.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameDbDefault, dbGegoennterKundeListItem.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameDbDefault, dbGegoennterKundeListItem.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanDbDefault, dbGegoennterKundeListItem.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeDbDefault, dbGegoennterKundeListItem.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleDbDefault, dbGegoennterKundeListItem.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidDbDefault, dbGegoennterKundeListItem.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerDbDefault, dbGegoennterKundeListItem.GegoennterInteger);
            DbGegoennteBankTest.AssertDbDefault(dbGegoennterKundeListItem.BesteBank);
        }

        public static void AssertDbDefault2(IDbGegoennterKundeListItem dbGegoennterKundeListItem)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDbDefault2, dbGegoennterKundeListItem.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameDbDefault2, dbGegoennterKundeListItem.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameDbDefault2, dbGegoennterKundeListItem.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanDbDefault2, dbGegoennterKundeListItem.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeDbDefault2, dbGegoennterKundeListItem.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleDbDefault2, dbGegoennterKundeListItem.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidDbDefault2, dbGegoennterKundeListItem.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerDbDefault2, dbGegoennterKundeListItem.GegoennterInteger);
            DbGegoennteBankTest.AssertDbDefault2(dbGegoennterKundeListItem.BesteBank);
        }
    }
}