using System;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.Bankwesen.Banken
{
    public class BankTestValues
    {
        public static readonly Guid IdDbDefault = Guid.Parse("d0c014cd-8c1e-464a-a8ee-974e2e09caa4");
        public static readonly Guid IdDbDefault2 = Guid.Parse("86514cfc-ec28-4ced-9fee-9ef09b8b8664");
        public static readonly Guid IdForCreate = Guid.Parse("ef102191-3206-44d3-af7c-a58f906a9494");
        public static readonly Guid IdForUpdate = Guid.Parse("4793952b-c6bc-4741-b127-35fe0e7ed8da");

        public static readonly string NameDbDefault = "NameDbDefault";
        public static readonly string NameDbDefault2 = "NameDbDefault2";
        public static readonly string NameForCreate = "NameForCreate";
        public static readonly string NameForUpdate = "NameForUpdate";

        public static readonly bool BooleanDbDefault = true;
        public static readonly bool BooleanDbDefault2 = false;
        public static readonly bool BooleanForCreate = false;
        public static readonly bool BooleanForUpdate = false;

        public static readonly DateTime DateTimeDbDefault = new DateTime(2017, 7, 5);
        public static readonly DateTime DateTimeDbDefault2 = new DateTime(2017, 2, 18);
        public static readonly DateTime DateTimeForCreate = new DateTime(2013, 6, 28);
        public static readonly DateTime DateTimeForUpdate = new DateTime(2017, 3, 8);

        public static readonly double DoubleDbDefault = 89.22507;
        public static readonly double DoubleDbDefault2 = 90.4755;
        public static readonly double DoubleForCreate = 45.82288;
        public static readonly double DoubleForUpdate = 88.90449;

        public static readonly Guid GuidDbDefault = Guid.Parse("6d9b2ac7-82a5-4b97-8367-558c4b780228");
        public static readonly Guid GuidDbDefault2 = Guid.Parse("816c0bda-07c1-48d1-b391-15231feede7b");
        public static readonly Guid GuidForCreate = Guid.Parse("11582361-47e9-4766-97b5-5499efe3df54");
        public static readonly Guid GuidForUpdate = Guid.Parse("e114c3c7-1a96-4656-8607-f8e03c1a0bc9");

        public static readonly int IntegerDbDefault = 905;
        public static readonly int IntegerDbDefault2 = 547;
        public static readonly int IntegerForCreate = 425;
        public static readonly int IntegerForUpdate = 326;
    }
}