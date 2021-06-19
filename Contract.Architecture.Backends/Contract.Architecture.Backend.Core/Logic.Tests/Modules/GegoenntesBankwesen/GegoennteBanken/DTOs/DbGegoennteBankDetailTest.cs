using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoennterKundenstamm.GegoennteKunden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoenntesBankwesen.GegoennteBanken
{
    internal class DbGegoennteBankDetailTest : IDbGegoennteBankDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool GegoennterBoolean { get; set; }

        public DateTime GegoenntesDateTime { get; set; }

        public double GegoennterDouble { get; set; }

        public Guid GegoennteGuid { get; set; }

        public int GegoennterInteger { get; set; }

        public IEnumerable<IDbGegoennterKunde> BesteKunden { get; set; }

        public static IDbGegoennteBankDetail Default()
        {
            return new DbGegoennteBankDetailTest()
            {
                Id = GegoennteBankTestValues.IdDefault,
                Name = GegoennteBankTestValues.NameDefault,
                GegoennterName = GegoennteBankTestValues.GegoennterNameDefault,
                GegoennterBoolean = GegoennteBankTestValues.GegoennterBooleanDefault,
                GegoenntesDateTime = GegoennteBankTestValues.GegoenntesDateTimeDefault,
                GegoennterDouble = GegoennteBankTestValues.GegoennterDoubleDefault,
                GegoennteGuid = GegoennteBankTestValues.GegoennteGuidDefault,
                GegoennterInteger = GegoennteBankTestValues.GegoennterIntegerDefault,
                BesteKunden = new List<IDbGegoennterKunde> { DbGegoennterKundeTest.Default() },
            };
        }

        public static IDbGegoennteBankDetail Default2()
        {
            return new DbGegoennteBankDetailTest()
            {
                Id = GegoennteBankTestValues.IdDefault,
                Name = GegoennteBankTestValues.NameDefault2,
                GegoennterName = GegoennteBankTestValues.GegoennterNameDefault2,
                GegoennterBoolean = GegoennteBankTestValues.GegoennterBooleanDefault2,
                GegoenntesDateTime = GegoennteBankTestValues.GegoenntesDateTimeDefault2,
                GegoennterDouble = GegoennteBankTestValues.GegoennterDoubleDefault2,
                GegoennteGuid = GegoennteBankTestValues.GegoennteGuidDefault2,
                GegoennterInteger = GegoennteBankTestValues.GegoennterIntegerDefault2,
                BesteKunden = new List<IDbGegoennterKunde> { DbGegoennterKundeTest.Default2() },
            };
        }

        public static void AssertDefault(IDbGegoennteBankDetail dbGegoennteBankDetail)
        {
            Assert.AreEqual(GegoennteBankTestValues.IdDefault, dbGegoennteBankDetail.Id);
            DbGegoennterKundeTest.AssertDefault(dbGegoennteBankDetail.BesteKunden.ToArray()[0]);
        }

        public static void AssertDefault2(IDbGegoennteBankDetail dbGegoennteBankDetail)
        {
            Assert.AreEqual(GegoennteBankTestValues.IdDefault2, dbGegoennteBankDetail.Id);
            Assert.AreEqual(GegoennteBankTestValues.NameDefault2, dbGegoennteBankDetail.Name);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterNameDefault2, dbGegoennteBankDetail.GegoennterName);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterBooleanDefault2, dbGegoennteBankDetail.GegoennterBoolean);
            Assert.AreEqual(GegoennteBankTestValues.GegoenntesDateTimeDefault2, dbGegoennteBankDetail.GegoenntesDateTime);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterDoubleDefault2, dbGegoennteBankDetail.GegoennterDouble);
            Assert.AreEqual(GegoennteBankTestValues.GegoennteGuidDefault2, dbGegoennteBankDetail.GegoennteGuid);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterIntegerDefault2, dbGegoennteBankDetail.GegoennterInteger);
            DbGegoennterKundeTest.AssertDefault2(dbGegoennteBankDetail.BesteKunden.ToArray()[0]);
        }
    }
}