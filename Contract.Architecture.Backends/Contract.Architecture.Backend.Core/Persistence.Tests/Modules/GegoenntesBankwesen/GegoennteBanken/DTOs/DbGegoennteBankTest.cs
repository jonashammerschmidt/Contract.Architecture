using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoenntesBankwesen.GegoennteBanken
{
    internal class DbGegoennteBankTest : IDbGegoennteBank
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool GegoennterBoolean { get; set; }

        public DateTime GegoenntesDateTime { get; set; }

        public double GegoennterDouble { get; set; }

        public Guid GegoennteGuid { get; set; }

        public int GegoennterInteger { get; set; }

        public static IDbGegoennteBank DbDefault()
        {
            return new DbGegoennteBankTest()
            {
                Id = GegoennteBankTestValues.IdDbDefault,
                Name = GegoennteBankTestValues.NameDbDefault,
                GegoennterName = GegoennteBankTestValues.GegoennterNameDbDefault,
                GegoennterBoolean = GegoennteBankTestValues.GegoennterBooleanDbDefault,
                GegoenntesDateTime = GegoennteBankTestValues.GegoenntesDateTimeDbDefault,
                GegoennterDouble = GegoennteBankTestValues.GegoennterDoubleDbDefault,
                GegoennteGuid = GegoennteBankTestValues.GegoennteGuidDbDefault,
                GegoennterInteger = GegoennteBankTestValues.GegoennterIntegerDbDefault,
            };
        }

        public static IDbGegoennteBank DbDefault2()
        {
            return new DbGegoennteBankTest()
            {
                Id = GegoennteBankTestValues.IdDbDefault2,
                Name = GegoennteBankTestValues.NameDbDefault2,
                GegoennterName = GegoennteBankTestValues.GegoennterNameDbDefault2,
                GegoennterBoolean = GegoennteBankTestValues.GegoennterBooleanDbDefault2,
                GegoenntesDateTime = GegoennteBankTestValues.GegoenntesDateTimeDbDefault2,
                GegoennterDouble = GegoennteBankTestValues.GegoennterDoubleDbDefault2,
                GegoennteGuid = GegoennteBankTestValues.GegoennteGuidDbDefault2,
                GegoennterInteger = GegoennteBankTestValues.GegoennterIntegerDbDefault2,
            };
        }

        public static IDbGegoennteBank ForCreate()
        {
            return new DbGegoennteBankTest()
            {
                Id = GegoennteBankTestValues.IdForCreate,
                Name = GegoennteBankTestValues.NameForCreate,
                GegoennterName = GegoennteBankTestValues.GegoennterNameForCreate,
                GegoennterBoolean = GegoennteBankTestValues.GegoennterBooleanForCreate,
                GegoenntesDateTime = GegoennteBankTestValues.GegoenntesDateTimeForCreate,
                GegoennterDouble = GegoennteBankTestValues.GegoennterDoubleForCreate,
                GegoennteGuid = GegoennteBankTestValues.GegoennteGuidForCreate,
                GegoennterInteger = GegoennteBankTestValues.GegoennterIntegerForCreate,
            };
        }

        public static IDbGegoennteBank ForUpdate()
        {
            return new DbGegoennteBankTest()
            {
                Id = GegoennteBankTestValues.IdDbDefault,
                Name = GegoennteBankTestValues.NameForUpdate,
                GegoennterName = GegoennteBankTestValues.GegoennterNameForUpdate,
                GegoennterBoolean = GegoennteBankTestValues.GegoennterBooleanForUpdate,
                GegoenntesDateTime = GegoennteBankTestValues.GegoenntesDateTimeForUpdate,
                GegoennterDouble = GegoennteBankTestValues.GegoennterDoubleForUpdate,
                GegoennteGuid = GegoennteBankTestValues.GegoennteGuidForUpdate,
                GegoennterInteger = GegoennteBankTestValues.GegoennterIntegerForUpdate,
            };
        }

        public static void AssertDbDefault(IDbGegoennteBank dbGegoennteBank)
        {
            Assert.AreEqual(GegoennteBankTestValues.IdDbDefault, dbGegoennteBank.Id);
            Assert.AreEqual(GegoennteBankTestValues.NameDbDefault, dbGegoennteBank.Name);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterNameDbDefault, dbGegoennteBank.GegoennterName);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterBooleanDbDefault, dbGegoennteBank.GegoennterBoolean);
            Assert.AreEqual(GegoennteBankTestValues.GegoenntesDateTimeDbDefault, dbGegoennteBank.GegoenntesDateTime);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterDoubleDbDefault, dbGegoennteBank.GegoennterDouble);
            Assert.AreEqual(GegoennteBankTestValues.GegoennteGuidDbDefault, dbGegoennteBank.GegoennteGuid);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterIntegerDbDefault, dbGegoennteBank.GegoennterInteger);
        }

        public static void AssertDbDefault2(IDbGegoennteBank dbGegoennteBank)
        {
            Assert.AreEqual(GegoennteBankTestValues.IdDbDefault2, dbGegoennteBank.Id);
            Assert.AreEqual(GegoennteBankTestValues.NameDbDefault2, dbGegoennteBank.Name);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterNameDbDefault2, dbGegoennteBank.GegoennterName);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterBooleanDbDefault2, dbGegoennteBank.GegoennterBoolean);
            Assert.AreEqual(GegoennteBankTestValues.GegoenntesDateTimeDbDefault2, dbGegoennteBank.GegoenntesDateTime);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterDoubleDbDefault2, dbGegoennteBank.GegoennterDouble);
            Assert.AreEqual(GegoennteBankTestValues.GegoennteGuidDbDefault2, dbGegoennteBank.GegoennteGuid);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterIntegerDbDefault2, dbGegoennteBank.GegoennterInteger);
        }

        public static void AssertForCreate(IDbGegoennteBank dbGegoennteBank)
        {
            Assert.AreEqual(GegoennteBankTestValues.IdForCreate, dbGegoennteBank.Id);
            Assert.AreEqual(GegoennteBankTestValues.NameForCreate, dbGegoennteBank.Name);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterNameForCreate, dbGegoennteBank.GegoennterName);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterBooleanForCreate, dbGegoennteBank.GegoennterBoolean);
            Assert.AreEqual(GegoennteBankTestValues.GegoenntesDateTimeForCreate, dbGegoennteBank.GegoenntesDateTime);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterDoubleForCreate, dbGegoennteBank.GegoennterDouble);
            Assert.AreEqual(GegoennteBankTestValues.GegoennteGuidForCreate, dbGegoennteBank.GegoennteGuid);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterIntegerForCreate, dbGegoennteBank.GegoennterInteger);
        }

        public static void AssertForUpdate(IDbGegoennteBank dbGegoennteBank)
        {
            Assert.AreEqual(GegoennteBankTestValues.IdDbDefault, dbGegoennteBank.Id);
            Assert.AreEqual(GegoennteBankTestValues.NameForUpdate, dbGegoennteBank.Name);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterNameForUpdate, dbGegoennteBank.GegoennterName);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterBooleanForUpdate, dbGegoennteBank.GegoennterBoolean);
            Assert.AreEqual(GegoennteBankTestValues.GegoenntesDateTimeForUpdate, dbGegoennteBank.GegoenntesDateTime);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterDoubleForUpdate, dbGegoennteBank.GegoennterDouble);
            Assert.AreEqual(GegoennteBankTestValues.GegoennteGuidForUpdate, dbGegoennteBank.GegoennteGuid);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterIntegerForUpdate, dbGegoennteBank.GegoennterInteger);
        }
    }
}