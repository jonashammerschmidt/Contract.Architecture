using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Bankwesen.Banken;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Bankwesen.Banken
{
    internal class BankCreateTest : IBankCreate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Boolean { get; set; }

        public DateTime DateTime { get; set; }

        public double Double { get; set; }

        public Guid Guid { get; set; }

        public int Integer { get; set; }

        public static IBankCreate ForCreate()
        {
            return new BankCreateTest()
            {
                Id = BankTestValues.IdForCreate,
                Name = BankTestValues.NameForCreate,
                Boolean = BankTestValues.BooleanForCreate,
                DateTime = BankTestValues.DateTimeForCreate,
                Double = BankTestValues.DoubleForCreate,
                Guid = BankTestValues.GuidForCreate,
                Integer = BankTestValues.IntegerForCreate,
            };
        }
    }
}