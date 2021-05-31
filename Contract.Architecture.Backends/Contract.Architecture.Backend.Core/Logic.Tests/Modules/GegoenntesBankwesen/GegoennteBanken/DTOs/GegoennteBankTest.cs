using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoenntesBankwesen.GegoennteBanken
{
    internal class GegoennteBankTest : IGegoennteBank
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool GegoennterBoolean { get; set; }

        public DateTime GegoenntesDateTime { get; set; }

        public double GegoennterDouble { get; set; }

        public Guid GegoennteGuid { get; set; }

        public int GegoennterInteger { get; set; }

        public static IGegoennteBank Default()
        {
            return new GegoennteBankTest()
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

        public static IGegoennteBank Default2()
        {
            return new GegoennteBankTest()
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

        public static void AssertDefault(IGegoennteBank gegoennteBank)
        {
            Assert.AreEqual(GegoennteBankTestValues.IdDefault, gegoennteBank.Id);
            Assert.AreEqual(GegoennteBankTestValues.NameDefault, gegoennteBank.Name);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterNameDefault, gegoennteBank.GegoennterName);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterBooleanDefault, gegoennteBank.GegoennterBoolean);
            Assert.AreEqual(GegoennteBankTestValues.GegoenntesDateTimeDefault, gegoennteBank.GegoenntesDateTime);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterDoubleDefault, gegoennteBank.GegoennterDouble);
            Assert.AreEqual(GegoennteBankTestValues.GegoennteGuidDefault, gegoennteBank.GegoennteGuid);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterIntegerDefault, gegoennteBank.GegoennterInteger);
        }

        public static void AssertDefault2(IGegoennteBank gegoennteBank)
        {
            Assert.AreEqual(GegoennteBankTestValues.IdDefault2, gegoennteBank.Id);
            Assert.AreEqual(GegoennteBankTestValues.NameDefault2, gegoennteBank.Name);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterNameDefault2, gegoennteBank.GegoennterName);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterBooleanDefault2, gegoennteBank.GegoennterBoolean);
            Assert.AreEqual(GegoennteBankTestValues.GegoenntesDateTimeDefault2, gegoennteBank.GegoenntesDateTime);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterDoubleDefault2, gegoennteBank.GegoennterDouble);
            Assert.AreEqual(GegoennteBankTestValues.GegoennteGuidDefault2, gegoennteBank.GegoennteGuid);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterIntegerDefault2, gegoennteBank.GegoennterInteger);
        }
    }
}