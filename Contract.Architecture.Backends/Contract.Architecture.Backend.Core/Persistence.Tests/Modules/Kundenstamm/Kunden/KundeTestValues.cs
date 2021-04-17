using Contract.Architecture.Backend.Core.Persistence.Tests.Modules.Bankwesen.Banken;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Tests.Modules.Kundenstamm.Kunden
{
    public class KundeTestValues
    {
        public static readonly Guid IdDbDefault = Guid.Parse("55f7eb10-2695-425f-8f94-6972224596c5");
        public static readonly Guid IdDbDefault2 = Guid.Parse("ba8e42a7-e4e5-49d0-aa79-51cec28050eb");
        public static readonly Guid IdForCreate = Guid.Parse("8f158ad5-a29e-4985-b6d1-d9a175a1cb0c");
        public static readonly Guid IdForUpdate = Guid.Parse("12f6d0bf-5372-4987-8e73-32adf39bfdc9");

        public static readonly string NameDbDefault = "NameDbDefault";
        public static readonly string NameDbDefault2 = "NameDbDefault2";
        public static readonly string NameForCreate = "NameForCreate";
        public static readonly string NameForUpdate = "NameForUpdate";

        public static readonly bool BooleanDbDefault = true;
        public static readonly bool BooleanDbDefault2 = false;
        public static readonly bool BooleanForCreate = false;
        public static readonly bool BooleanForUpdate = false;

        public static readonly DateTime DateTimeDbDefault = new DateTime(2019, 3, 27);
        public static readonly DateTime DateTimeDbDefault2 = new DateTime(2018, 9, 8);
        public static readonly DateTime DateTimeForCreate = new DateTime(2015, 11, 17);
        public static readonly DateTime DateTimeForUpdate = new DateTime(2020, 12, 12);

        public static readonly double DoubleDbDefault = 20.92601;
        public static readonly double DoubleDbDefault2 = 38.20190;
        public static readonly double DoubleForCreate = 16.34729;
        public static readonly double DoubleForUpdate = 32.73723;

        public static readonly Guid GuidDbDefault = Guid.Parse("d737e05d-73c0-4f51-8537-f0e16d60325f");
        public static readonly Guid GuidDbDefault2 = Guid.Parse("cf7026ea-1cf6-45fe-ba25-07f3183e358a");
        public static readonly Guid GuidForCreate = Guid.Parse("2495f86c-d871-48f7-ab41-fde4f88ea1c1");
        public static readonly Guid GuidForUpdate = Guid.Parse("b5f9606c-1002-4802-9fcf-92ee7b00c908");

        public static readonly int IntegerDbDefault = 726;
        public static readonly int IntegerDbDefault2 = 334;
        public static readonly int IntegerForCreate = 321;
        public static readonly int IntegerForUpdate = 173;

        public static readonly Guid BankIdDbDefault = BankTestValues.IdDbDefault;
        public static readonly Guid BankIdDbDefault2 = BankTestValues.IdDbDefault2;
        public static readonly Guid BankIdForCreate = BankTestValues.IdForCreate;
        public static readonly Guid BankIdForUpdate = BankTestValues.IdForUpdate;
    }
}