using Contract.Architecture.Backend.Core.Logic.Tests.Modules.Bankwesen.Banken;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.Kundenstamm.Kunden
{
    public class KundeTestValues
    {
        public static readonly Guid IdDefault = Guid.Parse("05faeeda-8524-4123-851f-c78a73c7cf03");
        public static readonly Guid IdForCreate = Guid.Parse("79e2cc92-0f00-4869-b216-1109bc104a44");
        public static readonly Guid IdForUpdate = Guid.Parse("6539b83c-292c-4fab-8887-30b5e7b809b9");

        public static readonly string NameDefault = "NameDefault";
        public static readonly string NameForCreate = "NameForCreate";
        public static readonly string NameForUpdate = "NameForUpdate";

        public static readonly bool BooleanDefault = false;
        public static readonly bool BooleanForCreate = false;
        public static readonly bool BooleanForUpdate = false;

        public static readonly DateTime DateTimeDefault = new DateTime(2020, 5, 25);
        public static readonly DateTime DateTimeForCreate = new DateTime(2012, 6, 16);
        public static readonly DateTime DateTimeForUpdate = new DateTime(2015, 1, 24);

        public static readonly double DoubleDefault = 78.85229;
        public static readonly double DoubleForCreate = 82.91801;
        public static readonly double DoubleForUpdate = 89.56970;

        public static readonly Guid GuidDefault = Guid.Parse("d04c85a7-b336-46f8-9218-c785cf516daa");
        public static readonly Guid GuidForCreate = Guid.Parse("8ef22524-bc11-473b-b4ca-284351f4967d");
        public static readonly Guid GuidForUpdate = Guid.Parse("f130df74-85fd-4ddb-b145-93d038e459d1");

        public static readonly int IntegerDefault = 423;
        public static readonly int IntegerForCreate = 210;
        public static readonly int IntegerForUpdate = 970;

        public static readonly Guid BankIdDefault = BankTestValues.IdDefault;
        public static readonly Guid BankIdForCreate = BankTestValues.IdForCreate;
        public static readonly Guid BankIdForUpdate = BankTestValues.IdForUpdate;
    }
}