using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoenntesBankwesen.GegoennteBanken;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
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

        public static IDbGegoennterKundeDetail Default()
        {
            return new DbGegoennterKundeDetailTest()
            {
                Id = GegoennterKundeTestValues.IdDefault,
                Name = GegoennterKundeTestValues.NameDefault,
                GegoennterName = GegoennterKundeTestValues.GegoennterNameDefault,
                GegoennterBoolean = GegoennterKundeTestValues.GegoennterBooleanDefault,
                GegoennterDateTime = GegoennterKundeTestValues.GegoennterDateTimeDefault,
                GegoennterDouble = GegoennterKundeTestValues.GegoennterDoubleDefault,
                GegoennterGuid = GegoennterKundeTestValues.GegoennterGuidDefault,
                GegoennterInteger = GegoennterKundeTestValues.GegoennterIntegerDefault,
                BesteBank = DbGegoennteBankTest.Default(),
            };
        }

        public static IDbGegoennterKundeDetail Default2()
        {
            return new DbGegoennterKundeDetailTest()
            {
                Id = GegoennterKundeTestValues.IdDefault,
                Name = GegoennterKundeTestValues.NameDefault2,
                GegoennterName = GegoennterKundeTestValues.GegoennterNameDefault2,
                GegoennterBoolean = GegoennterKundeTestValues.GegoennterBooleanDefault2,
                GegoennterDateTime = GegoennterKundeTestValues.GegoennterDateTimeDefault2,
                GegoennterDouble = GegoennterKundeTestValues.GegoennterDoubleDefault2,
                GegoennterGuid = GegoennterKundeTestValues.GegoennterGuidDefault2,
                GegoennterInteger = GegoennterKundeTestValues.GegoennterIntegerDefault2,
                BesteBank = DbGegoennteBankTest.Default2(),
            };
        }

        public static void AssertDefault(IDbGegoennterKundeDetail dbGegoennterKundeDetail)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDefault, dbGegoennterKundeDetail.Id);
            DbGegoennteBankTest.AssertDefault(dbGegoennterKundeDetail.BesteBank);
        }

        public static void AssertDefault2(IDbGegoennterKundeDetail dbGegoennterKundeDetail)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDefault2, dbGegoennterKundeDetail.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameDefault2, dbGegoennterKundeDetail.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameDefault2, dbGegoennterKundeDetail.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanDefault2, dbGegoennterKundeDetail.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeDefault2, dbGegoennterKundeDetail.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleDefault2, dbGegoennterKundeDetail.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidDefault2, dbGegoennterKundeDetail.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerDefault2, dbGegoennterKundeDetail.GegoennterInteger);
            DbGegoennteBankTest.AssertDefault2(dbGegoennterKundeDetail.BesteBank);
        }
    }
}