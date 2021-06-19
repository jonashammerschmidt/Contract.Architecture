using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden
{
    internal class DbGegoennterKundeDetail : IDbGegoennterKundeDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool? GegoennterBoolean { get; set; }

        public DateTime? GegoennterDateTime { get; set; }

        public double? GegoennterDouble { get; set; }

        public Guid? GegoennterGuid { get; set; }

        public int? GegoennterInteger { get; set; }

        public IDbGegoennteBank BesteBank { get; set; }

        internal static IDbGegoennterKundeDetail FromEfGegoennterKunde(EfGegoennterKunde efGegoennterKunde)
        {
            if (efGegoennterKunde == null)
            {
                return null;
            }

            return new DbGegoennterKundeDetail()
            {
                Id = efGegoennterKunde.Id,
                Name = efGegoennterKunde.Name,
                GegoennterName = efGegoennterKunde.GegoennterName,
                GegoennterBoolean = efGegoennterKunde.GegoennterBoolean,
                GegoennterDateTime = efGegoennterKunde.GegoennterDateTime,
                GegoennterDouble = efGegoennterKunde.GegoennterDouble,
                GegoennterGuid = efGegoennterKunde.GegoennterGuid,
                GegoennterInteger = efGegoennterKunde.GegoennterInteger,
                BesteBank = DbGegoennteBank.FromEfGegoennteBank(efGegoennterKunde.BesteBank),
            };
        }
    }
}