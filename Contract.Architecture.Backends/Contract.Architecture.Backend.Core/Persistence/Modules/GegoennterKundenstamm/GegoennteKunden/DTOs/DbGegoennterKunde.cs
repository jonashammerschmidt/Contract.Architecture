using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden
{
    internal class DbGegoennterKunde : IDbGegoennterKunde
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool? GegoennterBoolean { get; set; }

        public DateTime? GegoennterDateTime { get; set; }

        public double? GegoennterDouble { get; set; }

        public Guid? GegoennterGuid { get; set; }

        public int? GegoennterInteger { get; set; }

        public Guid BesteBankId { get; set; }

        internal static void UpdateEfGegoennterKunde(EfGegoennterKunde efGegoennterKunde, IDbGegoennterKunde dbGegoennterKunde)
        {
            efGegoennterKunde.Name = dbGegoennterKunde.Name;
            efGegoennterKunde.GegoennterName = dbGegoennterKunde.GegoennterName;
            efGegoennterKunde.GegoennterBoolean = dbGegoennterKunde.GegoennterBoolean;
            efGegoennterKunde.GegoennterDateTime = dbGegoennterKunde.GegoennterDateTime;
            efGegoennterKunde.GegoennterDouble = dbGegoennterKunde.GegoennterDouble;
            efGegoennterKunde.GegoennterGuid = dbGegoennterKunde.GegoennterGuid;
            efGegoennterKunde.GegoennterInteger = dbGegoennterKunde.GegoennterInteger;
            efGegoennterKunde.BesteBankId = dbGegoennterKunde.BesteBankId;
        }

        internal static IDbGegoennterKunde FromEfGegoennterKunde(EfGegoennterKunde efGegoennterKunde)
        {
            if (efGegoennterKunde == null)
            {
                return null;
            }

            return new DbGegoennterKunde()
            {
                Id = efGegoennterKunde.Id,
                Name = efGegoennterKunde.Name,
                GegoennterName = efGegoennterKunde.GegoennterName,
                GegoennterBoolean = efGegoennterKunde.GegoennterBoolean,
                GegoennterDateTime = efGegoennterKunde.GegoennterDateTime,
                GegoennterDouble = efGegoennterKunde.GegoennterDouble,
                GegoennterGuid = efGegoennterKunde.GegoennterGuid,
                GegoennterInteger = efGegoennterKunde.GegoennterInteger,
                BesteBankId = efGegoennterKunde.BesteBankId,
            };
        }

        internal static EfGegoennterKunde ToEfGegoennterKunde(IDbGegoennterKunde dbGegoennterKunde)
        {
            return new EfGegoennterKunde()
            {
                Id = dbGegoennterKunde.Id,
                Name = dbGegoennterKunde.Name,
                GegoennterName = dbGegoennterKunde.GegoennterName,
                GegoennterBoolean = dbGegoennterKunde.GegoennterBoolean,
                GegoennterDateTime = dbGegoennterKunde.GegoennterDateTime,
                GegoennterDouble = dbGegoennterKunde.GegoennterDouble,
                GegoennterGuid = dbGegoennterKunde.GegoennterGuid,
                GegoennterInteger = dbGegoennterKunde.GegoennterInteger,
                BesteBankId = dbGegoennterKunde.BesteBankId,
            };
        }
    }
}