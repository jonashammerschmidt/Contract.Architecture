using Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoenntesBankwesen.GegoennteBanken;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Modules.GegoennterKundenstamm.GegoennteKunden
{
    public class GegoennterKundeTestValues
    {
        public static readonly Guid IdDefault = Guid.Parse("88fe7c29-972b-4464-af8d-2e9f5de2d9b7");
        public static readonly Guid IdDefault2 = Guid.Parse("09428baf-4cf7-4357-8e42-84271ef79b55");
        public static readonly Guid IdForCreate = Guid.Parse("17562d0a-7284-4e23-a93a-e4de2b6b7367");

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

        public static readonly DateTime GegoennterDateTimeDefault = new DateTime(2019, 6, 18);
        public static readonly DateTime GegoennterDateTimeDefault2 = new DateTime(2013, 9, 22);
        public static readonly DateTime GegoennterDateTimeForCreate = new DateTime(2019, 5, 2);
        public static readonly DateTime GegoennterDateTimeForUpdate = new DateTime(2012, 4, 15);

        public static readonly double GegoennterDoubleDefault = 39.57796;
        public static readonly double GegoennterDoubleDefault2 = 36.81712;
        public static readonly double GegoennterDoubleForCreate = 89.36461;
        public static readonly double GegoennterDoubleForUpdate = 89.29183;

        public static readonly Guid GegoennterGuidDefault = Guid.Parse("b0f7a7b2-5bd6-4deb-8dfe-877784be2ea1");
        public static readonly Guid GegoennterGuidDefault2 = Guid.Parse("62e52a88-dab8-4612-bc09-108836ee58e4");
        public static readonly Guid GegoennterGuidForCreate = Guid.Parse("1706077c-0a4b-4115-92aa-4004e7591c8f");
        public static readonly Guid GegoennterGuidForUpdate = Guid.Parse("9d3d1763-514e-42e2-a47c-bf8579c0fc39");

        public static readonly int GegoennterIntegerDefault = 835;
        public static readonly int GegoennterIntegerDefault2 = 941;
        public static readonly int GegoennterIntegerForCreate = 991;
        public static readonly int GegoennterIntegerForUpdate = 648;

        public static readonly Guid BesteBankIdDefault = GegoennteBankTestValues.IdDefault;
        public static readonly Guid BesteBankIdDefault2 = GegoennteBankTestValues.IdDefault2;
        public static readonly Guid BesteBankIdForCreate = GegoennteBankTestValues.IdDefault;
        public static readonly Guid BesteBankIdForUpdate = GegoennteBankTestValues.IdDefault2;
    }
}