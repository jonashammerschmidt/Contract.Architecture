using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoenntesBankwesen.GegoennteBanken
{
    internal class GegoennteBankUpdateTest : IGegoennteBankUpdate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool GegoennterBoolean { get; set; }

        public DateTime GegoenntesDateTime { get; set; }

        public double GegoennterDouble { get; set; }

        public Guid GegoennteGuid { get; set; }

        public int GegoennterInteger { get; set; }

        public static IGegoennteBankUpdate ForUpdate()
        {
            return new GegoennteBankUpdateTest()
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
    }
}