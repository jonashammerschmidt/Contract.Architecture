using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoenntesBankwesen.GegoennteBanken;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
{
    internal class GegoennterKundeDetailTest : IGegoennterKundeDetail
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

        public static IGegoennterKundeDetail Default()
        {
            return new GegoennterKundeDetailTest()
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

        public static IGegoennterKundeDetail Default2()
        {
            return new GegoennterKundeDetailTest()
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

        public static void AssertDefault(IGegoennterKundeDetail gegoennterKundeDetail)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDefault, gegoennterKundeDetail.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameDefault, gegoennterKundeDetail.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameDefault, gegoennterKundeDetail.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanDefault, gegoennterKundeDetail.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeDefault, gegoennterKundeDetail.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleDefault, gegoennterKundeDetail.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidDefault, gegoennterKundeDetail.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerDefault, gegoennterKundeDetail.GegoennterInteger);
            GegoennteBankTest.AssertDefault(gegoennterKundeDetail.BesteBank);
        }

        public static void AssertDefault2(IGegoennterKundeDetail gegoennterKundeDetail)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDefault2, gegoennterKundeDetail.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameDefault2, gegoennterKundeDetail.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameDefault2, gegoennterKundeDetail.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanDefault2, gegoennterKundeDetail.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeDefault2, gegoennterKundeDetail.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleDefault2, gegoennterKundeDetail.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidDefault2, gegoennterKundeDetail.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerDefault2, gegoennterKundeDetail.GegoennterInteger);
            GegoennteBankTest.AssertDefault2(gegoennterKundeDetail.BesteBank);
        }
    }
}