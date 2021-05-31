using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken
{
    internal class DbGegoennteBankDetail : IDbGegoennteBankDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool GegoennterBoolean { get; set; }

        public DateTime GegoenntesDateTime { get; set; }

        public double GegoennterDouble { get; set; }

        public Guid GegoennteGuid { get; set; }

        public int GegoennterInteger { get; set; }

        public IEnumerable<IDbGegoennterKunde> BesteKunden { get; set; }

        internal static IDbGegoennteBankDetail FromEfGegoennteBank(EfGegoennteBank efGegoennteBank)
        {
            if (efGegoennteBank == null)
            {
                return null;
            }

            return new DbGegoennteBankDetail()
            {
                Id = efGegoennteBank.Id,
                Name = efGegoennteBank.Name,
                GegoennterName = efGegoennteBank.GegoennterName,
                GegoennterBoolean = efGegoennteBank.GegoennterBoolean,
                GegoenntesDateTime = efGegoennteBank.GegoenntesDateTime,
                GegoennterDouble = efGegoennteBank.GegoennterDouble,
                GegoennteGuid = efGegoennteBank.GegoennteGuid,
                GegoennterInteger = efGegoennteBank.GegoennterInteger,
                BesteKunden = efGegoennteBank.BesteKunden.Select(efGegoennterKunde => DbGegoennterKunde.FromEfGegoennterKunde(efGegoennterKunde)),
            };
        }
    }
}