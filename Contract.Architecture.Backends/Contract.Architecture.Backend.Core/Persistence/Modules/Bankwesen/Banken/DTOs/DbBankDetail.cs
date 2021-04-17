using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Persistence.Modules.Kundenstamm.Kunden;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.Bankwesen.Banken
{
    internal class DbBankDetail : IDbBankDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Boolean { get; set; }

        public DateTime DateTime { get; set; }

        public double Double { get; set; }

        public Guid Guid { get; set; }

        public int Integer { get; set; }

        public IEnumerable<IDbKunde> Kunden { get; set; }

        internal static IDbBankDetail FromEfBank(EfBank efBank)
        {
            if (efBank == null)
            {
                return null;
            }

            return new DbBankDetail()
            {
                Id = efBank.Id,
                Name = efBank.Name,
                Boolean = efBank.Boolean,
                DateTime = efBank.DateTime,
                Double = efBank.Double,
                Guid = efBank.Guid,
                Integer = efBank.Integer,
                Kunden = efBank.Kunden.Select(efKunde => DbKunde.FromEfKunde(efKunde)),
            };
        }
    }
}