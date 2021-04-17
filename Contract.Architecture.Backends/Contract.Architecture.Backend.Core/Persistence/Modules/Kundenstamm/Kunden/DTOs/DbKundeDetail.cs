using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Persistence.Modules.Bankwesen.Banken;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.Kundenstamm.Kunden
{
    internal class DbKundeDetail : IDbKundeDetail
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool? Boolean { get; set; }

        public DateTime? DateTime { get; set; }

        public double? Double { get; set; }

        public Guid? Guid { get; set; }

        public int? Integer { get; set; }

        public IDbBank Bank { get; set; }

        internal static IDbKundeDetail FromEfKunde(EfKunde efKunde)
        {
            if (efKunde == null)
            {
                return null;
            }

            return new DbKundeDetail()
            {
                Id = efKunde.Id,
                Name = efKunde.Name,
                Boolean = efKunde.Boolean,
                DateTime = efKunde.DateTime,
                Double = efKunde.Double,
                Guid = efKunde.Guid,
                Integer = efKunde.Integer,
                Bank = DbBank.FromEfBank(efKunde.Bank),
            };
        }
    }
}