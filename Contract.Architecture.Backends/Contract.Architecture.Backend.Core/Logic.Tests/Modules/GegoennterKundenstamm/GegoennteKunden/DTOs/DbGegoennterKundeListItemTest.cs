using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Tools.Pagination;
using Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Logic.Tests.Tools.Pagination;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
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

        public static IDbGegoennterKundeListItem Default()
        {
            return new DbGegoennterKundeListItemTest()
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

        public static IDbGegoennterKundeListItem Default2()
        {
            return new DbGegoennterKundeListItemTest()
            {
                Id = GegoennterKundeTestValues.IdDefault2,
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

        public static IDbPagedResult<IDbGegoennterKundeListItem> ForPaged()
        {
            return new DbPagedResult<IDbGegoennterKundeListItem>()
            {
                Data = new List<IDbGegoennterKundeListItem>()
                {
                    Default(),
                    Default2()
                },
                TotalCount = 2,
                Count = 2,
                Limit = 10,
                Offset = 0
            };
        }

        public static void AssertDefault(IDbGegoennterKundeListItem dbGegoennterKundeListItem)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDefault, dbGegoennterKundeListItem.Id);
            DbGegoennteBankTest.AssertDefault(dbGegoennterKundeListItem.BesteBank);
        }

        public static void AssertDefault2(IDbGegoennterKundeListItem dbGegoennterKundeListItem)
        {
            Assert.AreEqual(GegoennterKundeTestValues.IdDefault2, dbGegoennterKundeListItem.Id);
            Assert.AreEqual(GegoennterKundeTestValues.NameDefault2, dbGegoennterKundeListItem.Name);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterNameDefault2, dbGegoennterKundeListItem.GegoennterName);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterBooleanDefault2, dbGegoennterKundeListItem.GegoennterBoolean);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDateTimeDefault2, dbGegoennterKundeListItem.GegoennterDateTime);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterDoubleDefault2, dbGegoennterKundeListItem.GegoennterDouble);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterGuidDefault2, dbGegoennterKundeListItem.GegoennterGuid);
            Assert.AreEqual(GegoennterKundeTestValues.GegoennterIntegerDefault2, dbGegoennterKundeListItem.GegoennterInteger);
            DbGegoennteBankTest.AssertDefault2(dbGegoennterKundeListItem.BesteBank);
        }
    }
}