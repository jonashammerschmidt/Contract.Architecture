using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Kundenstamm.Kunden;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Modules.Kundenstamm.Kunden
{
    internal class Kunde : IKunde
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool? Boolean { get; set; }

        public DateTime? DateTime { get; set; }

        public double? Double { get; set; }

        public Guid? Guid { get; set; }

        public int? Integer { get; set; }

        public Guid BankId { get; set; }

        internal static void UpdateDbKunde(IDbKunde dbKunde, IKundeUpdate kundeUpdate)
        {
            dbKunde.Name = kundeUpdate.Name;
            dbKunde.Boolean = kundeUpdate.Boolean;
            dbKunde.DateTime = kundeUpdate.DateTime;
            dbKunde.Double = kundeUpdate.Double;
            dbKunde.Guid = kundeUpdate.Guid;
            dbKunde.Integer = kundeUpdate.Integer;
            dbKunde.BankId = kundeUpdate.BankId;
        }

        internal static IKunde FromDbKunde(IDbKunde dbKunde)
        {
            return new Kunde()
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

        internal static IDbKunde CreateDbKunde(Guid kundeId, IKundeCreate kundeCreate)
        {
            return new DbKunde()
            {
                Id = kundeId,
                Name = kundeCreate.Name,
                Boolean = kundeCreate.Boolean,
                DateTime = kundeCreate.DateTime,
                Double = kundeCreate.Double,
                Guid = kundeCreate.Guid,
                Integer = kundeCreate.Integer,
                BankId = kundeCreate.BankId,
            };
        }
    }
}