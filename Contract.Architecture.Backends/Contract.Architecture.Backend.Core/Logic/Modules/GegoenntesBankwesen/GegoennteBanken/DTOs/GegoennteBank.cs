using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Modules.GegoenntesBankwesen.GegoennteBanken
{
    internal class GegoennteBank : IGegoennteBank
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool GegoennterBoolean { get; set; }

        public DateTime GegoenntesDateTime { get; set; }

        public double GegoennterDouble { get; set; }

        public Guid GegoennteGuid { get; set; }

        public int GegoennterInteger { get; set; }

        internal static void UpdateDbGegoennteBank(IDbGegoennteBank dbGegoennteBank, IGegoennteBankUpdate gegoennteBankUpdate)
        {
            dbGegoennteBank.Name = gegoennteBankUpdate.Name;
            dbGegoennteBank.GegoennterName = gegoennteBankUpdate.GegoennterName;
            dbGegoennteBank.GegoennterBoolean = gegoennteBankUpdate.GegoennterBoolean;
            dbGegoennteBank.GegoenntesDateTime = gegoennteBankUpdate.GegoenntesDateTime;
            dbGegoennteBank.GegoennterDouble = gegoennteBankUpdate.GegoennterDouble;
            dbGegoennteBank.GegoennteGuid = gegoennteBankUpdate.GegoennteGuid;
            dbGegoennteBank.GegoennterInteger = gegoennteBankUpdate.GegoennterInteger;
        }

        internal static IGegoennteBank FromDbGegoennteBank(IDbGegoennteBank dbGegoennteBank)
        {
            return new GegoennteBank()
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

        internal static IDbGegoennteBank CreateDbGegoennteBank(Guid gegoennteBankId, IGegoennteBankCreate gegoennteBankCreate)
        {
            return new DbGegoennteBank()
            {
                Id = gegoennteBankId,
                Name = gegoennteBankCreate.Name,
                GegoennterName = gegoennteBankCreate.GegoennterName,
                GegoennterBoolean = gegoennteBankCreate.GegoennterBoolean,
                GegoenntesDateTime = gegoennteBankCreate.GegoenntesDateTime,
                GegoennterDouble = gegoennteBankCreate.GegoennterDouble,
                GegoennteGuid = gegoennteBankCreate.GegoennteGuid,
                GegoennterInteger = gegoennteBankCreate.GegoennterInteger,
            };
        }
    }
}