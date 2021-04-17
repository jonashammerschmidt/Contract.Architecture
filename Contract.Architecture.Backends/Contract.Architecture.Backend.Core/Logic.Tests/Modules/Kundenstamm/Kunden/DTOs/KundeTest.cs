using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Kundenstamm.Kunden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Kundenstamm.Kunden
{
    internal class KundeTest : IKunde
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool? Boolean { get; set; }

        public DateTime? DateTime { get; set; }

        public double? Double { get; set; }

        public Guid? Guid { get; set; }

        public int? Integer { get; set; }

        public Guid BankId { get; set; }

        public static IKunde Default()
        {
            return new KundeTest()
            {
                Id = KundeTestValues.IdDefault,
                Name = KundeTestValues.NameDefault,
                Boolean = KundeTestValues.BooleanDefault,
                DateTime = KundeTestValues.DateTimeDefault,
                Double = KundeTestValues.DoubleDefault,
                Guid = KundeTestValues.GuidDefault,
                Integer = KundeTestValues.IntegerDefault,
                BankId = KundeTestValues.BankIdDefault,
            };
        }

        public static void AssertDefault(IKunde kunde)
        {
            Assert.AreEqual(KundeTestValues.IdDefault, kunde.Id);
            Assert.AreEqual(KundeTestValues.NameDefault, kunde.Name);
            Assert.AreEqual(KundeTestValues.BooleanDefault, kunde.Boolean);
            Assert.AreEqual(KundeTestValues.DateTimeDefault, kunde.DateTime);
            Assert.AreEqual(KundeTestValues.DoubleDefault, kunde.Double);
            Assert.AreEqual(KundeTestValues.GuidDefault, kunde.Guid);
            Assert.AreEqual(KundeTestValues.IntegerDefault, kunde.Integer);
            Assert.AreEqual(KundeTestValues.BankIdDefault, kunde.BankId);
        }
    }
}