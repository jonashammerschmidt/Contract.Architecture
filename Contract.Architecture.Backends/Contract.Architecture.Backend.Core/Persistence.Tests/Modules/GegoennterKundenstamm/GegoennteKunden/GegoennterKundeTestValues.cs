using Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoenntesBankwesen.GegoennteBanken;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
{
    public class GegoennterKundeTestValues
    {
        public static readonly Guid IdDbDefault = Guid.Parse("c53343ba-0bb1-4478-8359-f2a72cd7d0b0");
        public static readonly Guid IdDbDefault2 = Guid.Parse("a21c600b-6166-4c2c-92d1-f96ae9752e77");
        public static readonly Guid IdForCreate = Guid.Parse("2370f170-8bab-4a2e-8078-bb7f94e84178");

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

        public static readonly DateTime GegoennterDateTimeDbDefault = new DateTime(2015, 6, 17);
        public static readonly DateTime GegoennterDateTimeDbDefault2 = new DateTime(2019, 7, 19);
        public static readonly DateTime GegoennterDateTimeForCreate = new DateTime(2012, 6, 20);
        public static readonly DateTime GegoennterDateTimeForUpdate = new DateTime(2014, 7, 11);

        public static readonly double GegoennterDoubleDbDefault = 62.48308;
        public static readonly double GegoennterDoubleDbDefault2 = 54.95015;
        public static readonly double GegoennterDoubleForCreate = 23.59692;
        public static readonly double GegoennterDoubleForUpdate = 33.75099;

        public static readonly Guid GegoennterGuidDbDefault = Guid.Parse("a91b8d93-9b2c-4c64-abaf-eb615ab6d3a1");
        public static readonly Guid GegoennterGuidDbDefault2 = Guid.Parse("4c22cea0-9452-4597-aee0-84f1d14d55e8");
        public static readonly Guid GegoennterGuidForCreate = Guid.Parse("1369b2dc-f60f-40d7-8572-1240d4031bf3");
        public static readonly Guid GegoennterGuidForUpdate = Guid.Parse("dd6e9957-69e3-4e86-9b56-b0530794b5e5");

        public static readonly int GegoennterIntegerDbDefault = 172;
        public static readonly int GegoennterIntegerDbDefault2 = 412;
        public static readonly int GegoennterIntegerForCreate = 480;
        public static readonly int GegoennterIntegerForUpdate = 389;

        public static readonly Guid BesteBankIdDbDefault = GegoennteBankTestValues.IdDbDefault;
        public static readonly Guid BesteBankIdDbDefault2 = GegoennteBankTestValues.IdDbDefault2;
        public static readonly Guid BesteBankIdForCreate = GegoennteBankTestValues.IdDbDefault;
        public static readonly Guid BesteBankIdForUpdate = GegoennteBankTestValues.IdDbDefault2;
    }
}