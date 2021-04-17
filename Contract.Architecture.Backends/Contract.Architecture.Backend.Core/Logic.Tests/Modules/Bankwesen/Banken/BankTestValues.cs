using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Bankwesen.Banken
{
    public class BankTestValues
    {
        public static readonly Guid IdDefault = Guid.Parse("aa4f7073-c60f-4219-8951-63de9df0761c");
        public static readonly Guid IdForCreate = Guid.Parse("60f522c3-d594-4583-b29e-b99b714a3d35");
        public static readonly Guid IdForUpdate = Guid.Parse("132e8949-e5e7-4d29-b94a-f06951b32436");

        public static readonly string NameDefault = "NameDefault";
        public static readonly string NameForCreate = "NameForCreate";
        public static readonly string NameForUpdate = "NameForUpdate";

        public static readonly bool BooleanDefault = false;
        public static readonly bool BooleanForCreate = false;
        public static readonly bool BooleanForUpdate = false;

        public static readonly DateTime DateTimeDefault = new DateTime(2020, 9, 8);
        public static readonly DateTime DateTimeForCreate = new DateTime(2017, 4, 5);
        public static readonly DateTime DateTimeForUpdate = new DateTime(2017, 1, 17);

        public static readonly double DoubleDefault = 76.21390;
        public static readonly double DoubleForCreate = 80.23417;
        public static readonly double DoubleForUpdate = 63.7219;

        public static readonly Guid GuidDefault = Guid.Parse("944c6f42-d9a6-49f3-a2ba-844dab5aebae");
        public static readonly Guid GuidForCreate = Guid.Parse("9ebe4ea7-8a75-458d-85ce-84de06d99581");
        public static readonly Guid GuidForUpdate = Guid.Parse("a27a7d1b-9bd5-4312-aa1f-7e93bc147bf8");

        public static readonly int IntegerDefault = 734;
        public static readonly int IntegerForCreate = 355;
        public static readonly int IntegerForUpdate = 506;
    }
}