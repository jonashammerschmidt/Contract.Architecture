using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Kundenstamm.Kunden;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.Kundenstamm.Kunden
{
    internal class DbKunde : IDbKunde
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool? Boolean { get; set; }

        public DateTime? DateTime { get; set; }

        public double? Double { get; set; }

        public Guid? Guid { get; set; }

        public int? Integer { get; set; }

        public Guid BankId { get; set; }

        internal static void UpdateEfKunde(EfKunde efKunde, IDbKunde dbKunde)
        {
            efKunde.Name = dbKunde.Name;
            efKunde.Boolean = dbKunde.Boolean;
            efKunde.DateTime = dbKunde.DateTime;
            efKunde.Double = dbKunde.Double;
            efKunde.Guid = dbKunde.Guid;
            efKunde.Integer = dbKunde.Integer;
            efKunde.BankId = dbKunde.BankId;
        }

        internal static IDbKunde FromEfKunde(EfKunde efKunde)
        {
            if (efKunde == null)
            {
                return null;
            }

            return new DbKunde()
            {
                Id = efKunde.Id,
                Name = efKunde.Name,
                Boolean = efKunde.Boolean,
                DateTime = efKunde.DateTime,
                Double = efKunde.Double,
                Guid = efKunde.Guid,
                Integer = efKunde.Integer,
                BankId = efKunde.BankId,
            };
        }

        internal static EfKunde ToEfKunde(IDbKunde dbKunde)
        {
            return new EfKunde()
            {
                Id = dbKunde.Id,
                Name = dbKunde.Name,
                Boolean = dbKunde.Boolean,
                DateTime = dbKunde.DateTime,
                Double = dbKunde.Double,
                Guid = dbKunde.Guid,
                Integer = dbKunde.Integer,
                BankId = dbKunde.BankId,
            };
        }
    }
}