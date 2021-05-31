using System;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.GegoenntesBankwesen.GegoennteBanken
{
    public class GegoennteBankTestValues
    {
        public static readonly Guid IdDbDefault = Guid.Parse("d9c8cde0-6bd0-4161-8d79-fa2fa4579892");
        public static readonly Guid IdDbDefault2 = Guid.Parse("a6ed8b9a-f12c-4e5a-b259-052c5002629c");
        public static readonly Guid IdForCreate = Guid.Parse("3b2c466c-8f99-4aa3-953e-6b1c9cb7f11b");

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

        public static readonly DateTime GegoenntesDateTimeDbDefault = new DateTime(2019, 8, 3);
        public static readonly DateTime GegoenntesDateTimeDbDefault2 = new DateTime(2021, 2, 23);
        public static readonly DateTime GegoenntesDateTimeForCreate = new DateTime(2020, 5, 16);
        public static readonly DateTime GegoenntesDateTimeForUpdate = new DateTime(2020, 1, 20);

        public static readonly double GegoennterDoubleDbDefault = 63.1227;
        public static readonly double GegoennterDoubleDbDefault2 = 64.74842;
        public static readonly double GegoennterDoubleForCreate = 28.539;
        public static readonly double GegoennterDoubleForUpdate = 59.73726;

        public static readonly Guid GegoennteGuidDbDefault = Guid.Parse("416a42f2-c626-4bb9-814a-19369898e787");
        public static readonly Guid GegoennteGuidDbDefault2 = Guid.Parse("4f0d528e-e191-4b76-a73e-dd71a0696eb2");
        public static readonly Guid GegoennteGuidForCreate = Guid.Parse("ac0a2a12-549d-4a39-b72e-7f278b30c5c0");
        public static readonly Guid GegoennteGuidForUpdate = Guid.Parse("8ef597af-f4f1-426b-8bce-d86e5dca6687");

        public static readonly int GegoennterIntegerDbDefault = 199;
        public static readonly int GegoennterIntegerDbDefault2 = 977;
        public static readonly int GegoennterIntegerForCreate = 409;
        public static readonly int GegoennterIntegerForUpdate = 170;
    }
}