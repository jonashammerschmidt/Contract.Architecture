using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoennterKundenstamm.GegoennteKunden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoenntesBankwesen.GegoennteBanken
{
    internal class GegoennteBankDetailTest : IGegoennteBankDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool GegoennterBoolean { get; set; }

        public DateTime GegoenntesDateTime { get; set; }

        public double GegoennterDouble { get; set; }

        public Guid GegoennteGuid { get; set; }

        public int GegoennterInteger { get; set; }

        public IEnumerable<IGegoennterKunde> BesteKunden { get; set; }

        public static IGegoennteBankDetail Default()
        {
            return new GegoennteBankDetailTest()
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

        public static IGegoennteBankDetail Default2()
        {
            return new GegoennteBankDetailTest()
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

        public static void AssertDefault(IGegoennteBankDetail gegoennteBankDetail)
        {
            Assert.AreEqual(GegoennteBankTestValues.IdDefault, gegoennteBankDetail.Id);
            Assert.AreEqual(GegoennteBankTestValues.NameDefault, gegoennteBankDetail.Name);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterNameDefault, gegoennteBankDetail.GegoennterName);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterBooleanDefault, gegoennteBankDetail.GegoennterBoolean);
            Assert.AreEqual(GegoennteBankTestValues.GegoenntesDateTimeDefault, gegoennteBankDetail.GegoenntesDateTime);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterDoubleDefault, gegoennteBankDetail.GegoennterDouble);
            Assert.AreEqual(GegoennteBankTestValues.GegoennteGuidDefault, gegoennteBankDetail.GegoennteGuid);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterIntegerDefault, gegoennteBankDetail.GegoennterInteger);
            GegoennterKundeTest.AssertDefault(gegoennteBankDetail.BesteKunden.ToArray()[0]);
        }

        public static void AssertDefault2(IGegoennteBankDetail gegoennteBankDetail)
        {
            Assert.AreEqual(GegoennteBankTestValues.IdDefault2, gegoennteBankDetail.Id);
            Assert.AreEqual(GegoennteBankTestValues.NameDefault2, gegoennteBankDetail.Name);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterNameDefault2, gegoennteBankDetail.GegoennterName);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterBooleanDefault2, gegoennteBankDetail.GegoennterBoolean);
            Assert.AreEqual(GegoennteBankTestValues.GegoenntesDateTimeDefault2, gegoennteBankDetail.GegoenntesDateTime);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterDoubleDefault2, gegoennteBankDetail.GegoennterDouble);
            Assert.AreEqual(GegoennteBankTestValues.GegoennteGuidDefault2, gegoennteBankDetail.GegoennteGuid);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterIntegerDefault2, gegoennteBankDetail.GegoennterInteger);
            GegoennterKundeTest.AssertDefault2(gegoennteBankDetail.BesteKunden.ToArray()[0]);
        }
    }
}