using Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoenntesBankwesen.GegoennteBanken;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
{
    public class GegoennterKundeTestValues
    {
        public static readonly Guid IdDefault = Guid.Parse("2a5b2202-9b39-43df-844b-9e420c958552");
        public static readonly Guid IdDefault2 = Guid.Parse("6d1abfeb-f796-4d7a-97cb-5935846e4876");
        public static readonly Guid IdForCreate = Guid.Parse("6814f7c1-1551-48a5-ab1a-5ae4b1113f6c");

        public static readonly string NameDefault = "NameDefault";
        public static readonly string NameDefault2 = "NameDefault2";
        public static readonly string NameForCreate = "NameForCreate";
        public static readonly string NameForUpdate = "NameForUpdate";

        public static readonly string GegoennterNameDefault = "GegoennterNameDefault";
        public static readonly string GegoennterNameDefault2 = "GegoennterNameDefault2";
        public static readonly string GegoennterNameForCreate = "GegoennterNameForCreate";
        public static readonly string GegoennterNameForUpdate = "GegoennterNameForUpdate";

        public static readonly bool GegoennterBooleanDefault = false;
        public static readonly bool GegoennterBooleanDefault2 = false;
        public static readonly bool GegoennterBooleanForCreate = false;
        public static readonly bool GegoennterBooleanForUpdate = false;

        public static readonly DateTime GegoennterDateTimeDefault = new DateTime(2021, 5, 19);
        public static readonly DateTime GegoennterDateTimeDefault2 = new DateTime(2017, 2, 18);
        public static readonly DateTime GegoennterDateTimeForCreate = new DateTime(2014, 8, 14);
        public static readonly DateTime GegoennterDateTimeForUpdate = new DateTime(2018, 1, 3);

        public static readonly double GegoennterDoubleDefault = 44.26670;
        public static readonly double GegoennterDoubleDefault2 = 44.53405;
        public static readonly double GegoennterDoubleForCreate = 10.38317;
        public static readonly double GegoennterDoubleForUpdate = 12.89450;

        public static readonly Guid GegoennterGuidDefault = Guid.Parse("d3687370-cb1d-42d4-ab47-a36289625106");
        public static readonly Guid GegoennterGuidDefault2 = Guid.Parse("6966825d-41b7-46d1-81b3-88f38ab5fc29");
        public static readonly Guid GegoennterGuidForCreate = Guid.Parse("ea3ddfc7-d686-4e48-b96e-d5dc4e50eb4b");
        public static readonly Guid GegoennterGuidForUpdate = Guid.Parse("90205f9e-6eb8-4300-bdd9-17906518eb8a");

        public static readonly int GegoennterIntegerDefault = 789;
        public static readonly int GegoennterIntegerDefault2 = 588;
        public static readonly int GegoennterIntegerForCreate = 609;
        public static readonly int GegoennterIntegerForUpdate = 751;

        public static readonly Guid BesteBankIdDefault = GegoennteBankTestValues.IdDefault;
        public static readonly Guid BesteBankIdDefault2 = GegoennteBankTestValues.IdDefault2;
        public static readonly Guid BesteBankIdForCreate = GegoennteBankTestValues.IdDefault;
        public static readonly Guid BesteBankIdForUpdate = GegoennteBankTestValues.IdDefault2;
    }
}