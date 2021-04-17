using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Bankwesen.Banken;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Bankwesen.Banken
{
    internal class BankUpdateTest : IBankUpdate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Boolean { get; set; }

        public DateTime DateTime { get; set; }

        public double Double { get; set; }

        public Guid Guid { get; set; }

        public int Integer { get; set; }

        public static IBankUpdate ForUpdate()
        {
            return new BankUpdateTest()
            {
                Id = BankTestValues.IdDefault,
                Name = BankTestValues.NameForUpdate,
                Boolean = BankTestValues.BooleanForUpdate,
                DateTime = BankTestValues.DateTimeForUpdate,
                Double = BankTestValues.DoubleForUpdate,
                Guid = BankTestValues.GuidForUpdate,
                Integer = BankTestValues.IntegerForUpdate,
            };
        }
    }
}