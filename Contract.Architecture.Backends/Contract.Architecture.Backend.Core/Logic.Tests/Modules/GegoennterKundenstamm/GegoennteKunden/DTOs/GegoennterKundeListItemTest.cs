using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoenntesBankwesen.GegoennteBanken;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
{
    internal class GegoennterKundeListItemTest : IGegoennterKundeListItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool? GegoennterBoolean { get; set; }

        public DateTime? GegoennterDateTime { get; set; }

        public double? GegoennterDouble { get; set; }

        public Guid? GegoennterGuid { get; set; }

        public int? GegoennterInteger { get; set; }

        public IGegoennteBank BesteBank { get; set; }

        public static IGegoennterKundeListItem Default()
        {
            return new GegoennterKundeListItemTest()
            {
                Id = GegoennterKundeTestValues.IdDefault,
                Name = GegoennterKundeTestValues.NameDefault,
                GegoennterName = GegoennterKundeTestValues.GegoennterNameDefault,
                GegoennterBoolean = GegoennterKundeTestValues.GegoennterBooleanDefault,
                GegoennterDateTime = GegoennterKundeTestValues.GegoennterDateTimeDefault,
                GegoennterDouble = GegoennterKundeTestValues.GegoennterDoubleDefault,
                GegoennterGuid = GegoennterKundeTestValues.GegoennterGuidDefault,
                GegoennterInteger = GegoennterKundeTestValues.GegoennterIntegerDefault,
            };
        }

        public static IGegoennterKundeListItem Default2()
        {
            return new GegoennterKundeListItemTest()
            {
                Id = GegoennterKundeTestValues.IdDefault2,
                Name = GegoennterKundeTestValues.NameDefault2,
                GegoennterName = GegoennterKundeTestValues.GegoennterNameDefault2,
                GegoennterBoolean = GegoennterKundeTestValues.GegoennterBooleanDefault2,
                GegoennterDateTime = GegoennterKundeTestValues.GegoennterDateTimeDefault2,
                GegoennterDouble = GegoennterKundeTestValues.GegoennterDoubleDefault2,
                GegoennterGuid = GegoennterKundeTestValues.GegoennterGuidDefault2,
                GegoennterInteger = GegoennterKundeTestValues.GegoennterIntegerDefault2,
            };
        }

        public static void AssertDefault(IGegoennterKundeListItem gegoennterKundeListItem)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDefault, gegoennterKundeListItem.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameDefault, gegoennterKundeListItem.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameDefault, gegoennterKundeListItem.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanDefault, gegoennterKundeListItem.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeDefault, gegoennterKundeListItem.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleDefault, gegoennterKundeListItem.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidDefault, gegoennterKundeListItem.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerDefault, gegoennterKundeListItem.GegoennterInteger);
            GegoennteBankTest.AssertDefault(gegoennterKundeListItem.BesteBank);
        }

        public static void AssertDefault2(IGegoennterKundeListItem gegoennterKundeListItem)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDefault2, gegoennterKundeListItem.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameDefault2, gegoennterKundeListItem.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameDefault2, gegoennterKundeListItem.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanDefault2, gegoennterKundeListItem.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeDefault2, gegoennterKundeListItem.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleDefault2, gegoennterKundeListItem.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidDefault2, gegoennterKundeListItem.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerDefault2, gegoennterKundeListItem.GegoennterInteger);
            GegoennteBankTest.AssertDefault2(gegoennterKundeListItem.BesteBank);
        }
    }
}