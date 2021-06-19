using System;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoenntesBankwesen.GegoennteBanken
{
    public class GegoennteBankTestValues
    {
        public static readonly Guid IdDbDefault = Guid.Parse("a0fb1d42-b02e-43b8-9fd2-cb37ea6dc0fa");
        public static readonly Guid IdDbDefault2 = Guid.Parse("bd805848-afc8-4bf2-877c-69678adc5fe4");
        public static readonly Guid IdForCreate = Guid.Parse("4fe15d3e-302f-4ed2-88f6-2786f14fb02e");

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

        public static readonly DateTime GegoenntesDateTimeDbDefault = new DateTime(2012, 3, 20);
        public static readonly DateTime GegoenntesDateTimeDbDefault2 = new DateTime(2018, 7, 12);
        public static readonly DateTime GegoenntesDateTimeForCreate = new DateTime(2012, 6, 3);
        public static readonly DateTime GegoenntesDateTimeForUpdate = new DateTime(2021, 3, 19);

        public static readonly double GegoennterDoubleDbDefault = 94.45391;
        public static readonly double GegoennterDoubleDbDefault2 = 59.94145;
        public static readonly double GegoennterDoubleForCreate = 77.64131;
        public static readonly double GegoennterDoubleForUpdate = 68.19472;

        public static readonly Guid GegoennteGuidDbDefault = Guid.Parse("d8a7c88c-22c6-43fa-8523-fa0f9644fff9");
        public static readonly Guid GegoennteGuidDbDefault2 = Guid.Parse("b00fe822-8642-472a-b851-252c4ee284f8");
        public static readonly Guid GegoennteGuidForCreate = Guid.Parse("9b205bdf-2296-44a7-a6a8-cd0a78dc93f3");
        public static readonly Guid GegoennteGuidForUpdate = Guid.Parse("b80e04d1-977d-4967-92f0-b3c725c184d7");

        public static readonly int GegoennterIntegerDbDefault = 395;
        public static readonly int GegoennterIntegerDbDefault2 = 405;
        public static readonly int GegoennterIntegerForCreate = 561;
        public static readonly int GegoennterIntegerForUpdate = 429;
    }
}