using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Tools.Pagination;
using Contract.Architecture.Backend.Core.Logic.Tests.Tools.Pagination;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoenntesBankwesen.GegoennteBanken
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

        public static IDbGegoennteBank Default()
        {
            return new DbGegoennteBankTest()
            {
                Id = GegoennteBankTestValues.IdDefault,
                Name = GegoennteBankTestValues.NameDefault,
                GegoennterName = GegoennteBankTestValues.GegoennterNameDefault,
                GegoennterBoolean = GegoennteBankTestValues.GegoennterBooleanDefault,
                GegoenntesDateTime = GegoennteBankTestValues.GegoenntesDateTimeDefault,
                GegoennterDouble = GegoennteBankTestValues.GegoennterDoubleDefault,
                GegoennteGuid = GegoennteBankTestValues.GegoennteGuidDefault,
                GegoennterInteger = GegoennteBankTestValues.GegoennterIntegerDefault,
            };
        }

        public static IDbGegoennteBank Default2()
        {
            return new DbGegoennteBankTest()
            {
                Id = GegoennteBankTestValues.IdDefault2,
                Name = GegoennteBankTestValues.NameDefault2,
                GegoennterName = GegoennteBankTestValues.GegoennterNameDefault2,
                GegoennterBoolean = GegoennteBankTestValues.GegoennterBooleanDefault2,
                GegoenntesDateTime = GegoennteBankTestValues.GegoenntesDateTimeDefault2,
                GegoennterDouble = GegoennteBankTestValues.GegoennterDoubleDefault2,
                GegoennteGuid = GegoennteBankTestValues.GegoennteGuidDefault2,
                GegoennterInteger = GegoennteBankTestValues.GegoennterIntegerDefault2,
            };
        }

        public static IDbGegoennteBank ForUpdate()
        {
            return new DbGegoennteBankTest()
            {
                Id = GegoennteBankTestValues.IdDefault,
                Name = GegoennteBankTestValues.NameForUpdate,
                GegoennterName = GegoennteBankTestValues.GegoennterNameForUpdate,
                GegoennterBoolean = GegoennteBankTestValues.GegoennterBooleanForUpdate,
                GegoenntesDateTime = GegoennteBankTestValues.GegoenntesDateTimeForUpdate,
                GegoennterDouble = GegoennteBankTestValues.GegoennterDoubleForUpdate,
                GegoennteGuid = GegoennteBankTestValues.GegoennteGuidForUpdate,
                GegoennterInteger = GegoennteBankTestValues.GegoennterIntegerForUpdate,
            };
        }

        public static IDbPagedResult<IDbGegoennteBank> ForPaged()
        {
            return new DbPagedResult<IDbGegoennteBank>()
            {
                Data = new List<IDbGegoennteBank>()
                {
                    DbGegoennteBankTest.Default(),
                    DbGegoennteBankTest.Default2()
                },
                TotalCount = 2,
                Count = 2,
                Limit = 10,
                Offset = 0
            };
        }

        public static void AssertDefault(IDbGegoennteBank dbGegoennteBank)
        {
            Assert.AreEqual(GegoennteBankTestValues.IdDefault, dbGegoennteBank.Id);
            Assert.AreEqual(GegoennteBankTestValues.NameDefault, dbGegoennteBank.Name);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterNameDefault, dbGegoennteBank.GegoennterName);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterBooleanDefault, dbGegoennteBank.GegoennterBoolean);
            Assert.AreEqual(GegoennteBankTestValues.GegoenntesDateTimeDefault, dbGegoennteBank.GegoenntesDateTime);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterDoubleDefault, dbGegoennteBank.GegoennterDouble);
            Assert.AreEqual(GegoennteBankTestValues.GegoennteGuidDefault, dbGegoennteBank.GegoennteGuid);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterIntegerDefault, dbGegoennteBank.GegoennterInteger);
        }

        public static void AssertDefault2(IDbGegoennteBank dbGegoennteBank)
        {
            Assert.AreEqual(GegoennteBankTestValues.IdDefault2, dbGegoennteBank.Id);
            Assert.AreEqual(GegoennteBankTestValues.NameDefault2, dbGegoennteBank.Name);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterNameDefault2, dbGegoennteBank.GegoennterName);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterBooleanDefault2, dbGegoennteBank.GegoennterBoolean);
            Assert.AreEqual(GegoennteBankTestValues.GegoenntesDateTimeDefault2, dbGegoennteBank.GegoenntesDateTime);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterDoubleDefault2, dbGegoennteBank.GegoennterDouble);
            Assert.AreEqual(GegoennteBankTestValues.GegoennteGuidDefault2, dbGegoennteBank.GegoennteGuid);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterIntegerDefault2, dbGegoennteBank.GegoennterInteger);
        }

        public static void AssertCreated(IDbGegoennteBank dbGegoennteBank)
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

        public static void AssertUpdated(IDbGegoennteBank dbGegoennteBank)
        {
            Assert.AreEqual(GegoennteBankTestValues.IdDefault, dbGegoennteBank.Id);
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