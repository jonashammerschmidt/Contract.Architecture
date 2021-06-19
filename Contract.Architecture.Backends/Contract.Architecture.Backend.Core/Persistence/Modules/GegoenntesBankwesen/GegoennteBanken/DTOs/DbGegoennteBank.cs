using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken
{
    internal class DbGegoennteBank : IDbGegoennteBank
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool GegoennterBoolean { get; set; }

        public DateTime GegoenntesDateTime { get; set; }

        public double GegoennterDouble { get; set; }

        public Guid GegoennteGuid { get; set; }

        public int GegoennterInteger { get; set; }

        internal static void UpdateEfGegoennteBank(EfGegoennteBank efGegoennteBank, IDbGegoennteBank dbGegoennteBank)
        {
            efGegoennteBank.Name = dbGegoennteBank.Name;
            efGegoennteBank.GegoennterName = dbGegoennteBank.GegoennterName;
            efGegoennteBank.GegoennterBoolean = dbGegoennteBank.GegoennterBoolean;
            efGegoennteBank.GegoenntesDateTime = dbGegoennteBank.GegoenntesDateTime;
            efGegoennteBank.GegoennterDouble = dbGegoennteBank.GegoennterDouble;
            efGegoennteBank.GegoennteGuid = dbGegoennteBank.GegoennteGuid;
            efGegoennteBank.GegoennterInteger = dbGegoennteBank.GegoennterInteger;
        }

        internal static IDbGegoennteBank FromEfGegoennteBank(EfGegoennteBank efGegoennteBank)
        {
            if (efGegoennteBank == null)
            {
                return null;
            }

            return new DbGegoennteBank()
            {
                Id = efGegoennteBank.Id,
                Name = efGegoennteBank.Name,
                GegoennterName = efGegoennteBank.GegoennterName,
                GegoennterBoolean = efGegoennteBank.GegoennterBoolean,
                GegoenntesDateTime = efGegoennteBank.GegoenntesDateTime,
                GegoennterDouble = efGegoennteBank.GegoennterDouble,
                GegoennteGuid = efGegoennteBank.GegoennteGuid,
                GegoennterInteger = efGegoennteBank.GegoennterInteger,
            };
        }

        internal static EfGegoennteBank ToEfGegoennteBank(IDbGegoennteBank dbGegoennteBank)
        {
            return new EfGegoennteBank()
            {
                Id = dbGegoennteBank.Id,
                Name = dbGegoennteBank.Name,
                GegoennterName = dbGegoennteBank.GegoennterName,
                GegoennterBoolean = dbGegoennteBank.GegoennterBoolean,
                GegoenntesDateTime = dbGegoennteBank.GegoenntesDateTime,
                GegoennterDouble = dbGegoennteBank.GegoennterDouble,
                GegoennteGuid = dbGegoennteBank.GegoennteGuid,
                GegoennterInteger = dbGegoennteBank.GegoennterInteger,
            };
        }
    }
}