using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoenntesBankwesen.GegoennteBanken
{
    internal class GegoennteBankCreateTest : IGegoennteBankCreate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool GegoennterBoolean { get; set; }

        public DateTime GegoenntesDateTime { get; set; }

        public double GegoennterDouble { get; set; }

        public Guid GegoennteGuid { get; set; }

        public int GegoennterInteger { get; set; }

        public static IGegoennteBankCreate ForCreate()
        {
            return new GegoennteBankCreateTest()
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
    }
}