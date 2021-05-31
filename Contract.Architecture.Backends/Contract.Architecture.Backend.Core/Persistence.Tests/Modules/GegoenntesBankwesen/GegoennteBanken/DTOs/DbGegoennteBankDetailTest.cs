using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoennterKundenstamm.GegoennteKunden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoenntesBankwesen.GegoennteBanken
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

        public static void AssertDbDefault(IDbGegoennteBankDetail dbGegoennteBankDetail)
        {
            Assert.AreEqual(GegoennteBankTestValues.IdDbDefault, dbGegoennteBankDetail.Id);
            Assert.AreEqual(GegoennteBankTestValues.NameDbDefault, dbGegoennteBankDetail.Name);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterNameDbDefault, dbGegoennteBankDetail.GegoennterName);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterBooleanDbDefault, dbGegoennteBankDetail.GegoennterBoolean);
            Assert.AreEqual(GegoennteBankTestValues.GegoenntesDateTimeDbDefault, dbGegoennteBankDetail.GegoenntesDateTime);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterDoubleDbDefault, dbGegoennteBankDetail.GegoennterDouble);
            Assert.AreEqual(GegoennteBankTestValues.GegoennteGuidDbDefault, dbGegoennteBankDetail.GegoennteGuid);
            Assert.AreEqual(GegoennteBankTestValues.GegoennterIntegerDbDefault, dbGegoennteBankDetail.GegoennterInteger);
            DbGegoennterKundeTest.AssertDbDefault(dbGegoennteBankDetail.BesteKunden.ToArray()[0]);
        }
    }
}