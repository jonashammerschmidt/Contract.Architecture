using Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoenntesBankwesen.GegoennteBanken;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
{
    public class GegoennterKundeTestValues
    {
        public static readonly Guid IdDbDefault = Guid.Parse("7e68bf1f-c286-419e-9362-e7815cd58862");
        public static readonly Guid IdDbDefault2 = Guid.Parse("6be8192f-0f27-441a-b422-11b822842ce3");
        public static readonly Guid IdForCreate = Guid.Parse("56f6ba3f-5981-4d61-9b3d-d83bdafd38f3");

        public static readonly string NameDbDefault = "NameDbDefault";
        public static readonly string NameDbDefault2 = "NameDbDefault2";
        public static readonly string NameForCreate = "NameForCreate";
        public static readonly string NameForUpdate = "NameForUpdate";

        public static readonly string GegoennterNameDbDefault = "GegoennterNameDbDefault";
        public static readonly string GegoennterNameDbDefault2 = "GegoennterNameDbDefault2";
        public static readonly string GegoennterNameForCreate = "GegoennterNameForCreate";
        public static readonly string GegoennterNameForUpdate = "GegoennterNameForUpdate";

        public static readonly bool GegoennterBooleanDbDefault = true;
        public static readonly bool GegoennterBooleanDbDefault2 = false;
        public static readonly bool GegoennterBooleanForCreate = false;
        public static readonly bool GegoennterBooleanForUpdate = false;

        public static readonly DateTime GegoennterDateTimeDbDefault = new DateTime(2014, 3, 28);
        public static readonly DateTime GegoennterDateTimeDbDefault2 = new DateTime(2019, 3, 20);
        public static readonly DateTime GegoennterDateTimeForCreate = new DateTime(2020, 12, 21);
        public static readonly DateTime GegoennterDateTimeForUpdate = new DateTime(2014, 4, 1);

        public static readonly double GegoennterDoubleDbDefault = 23.28423;
        public static readonly double GegoennterDoubleDbDefault2 = 98.35234;
        public static readonly double GegoennterDoubleForCreate = 48.32448;
        public static readonly double GegoennterDoubleForUpdate = 42.56823;

        public static readonly Guid GegoennterGuidDbDefault = Guid.Parse("0f983aeb-05c9-43b0-af71-1daad0927974");
        public static readonly Guid GegoennterGuidDbDefault2 = Guid.Parse("5b01bb7e-9009-414c-81fc-c31f624ba542");
        public static readonly Guid GegoennterGuidForCreate = Guid.Parse("c03a8a9a-109c-4ecf-96e2-675095dee37f");
        public static readonly Guid GegoennterGuidForUpdate = Guid.Parse("95c77f9d-80c6-4f0e-98ac-a377e2c1236e");

        public static readonly int GegoennterIntegerDbDefault = 947;
        public static readonly int GegoennterIntegerDbDefault2 = 992;
        public static readonly int GegoennterIntegerForCreate = 776;
        public static readonly int GegoennterIntegerForUpdate = 486;

        public static readonly Guid BesteBankIdDbDefault = GegoennteBankTestValues.IdDbDefault;
        public static readonly Guid BesteBankIdDbDefault2 = GegoennteBankTestValues.IdDbDefault2;
        public static readonly Guid BesteBankIdForCreate = GegoennteBankTestValues.IdDbDefault;
        public static readonly Guid BesteBankIdForUpdate = GegoennteBankTestValues.IdDbDefault2;
    }
}