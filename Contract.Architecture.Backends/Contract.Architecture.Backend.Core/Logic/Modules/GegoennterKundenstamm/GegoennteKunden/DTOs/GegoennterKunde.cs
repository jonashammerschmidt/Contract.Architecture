using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Modules.GegoennterKundenstamm.GegoennteKunden
{
    internal class GegoennterKunde : IGegoennterKunde
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

        internal static void UpdateDbGegoennterKunde(IDbGegoennterKunde dbGegoennterKunde, IGegoennterKundeUpdate gegoennterKundeUpdate)
        {
            dbGegoennterKunde.Name = gegoennterKundeUpdate.Name;
            dbGegoennterKunde.GegoennterName = gegoennterKundeUpdate.GegoennterName;
            dbGegoennterKunde.GegoennterBoolean = gegoennterKundeUpdate.GegoennterBoolean;
            dbGegoennterKunde.GegoennterDateTime = gegoennterKundeUpdate.GegoennterDateTime;
            dbGegoennterKunde.GegoennterDouble = gegoennterKundeUpdate.GegoennterDouble;
            dbGegoennterKunde.GegoennterGuid = gegoennterKundeUpdate.GegoennterGuid;
            dbGegoennterKunde.GegoennterInteger = gegoennterKundeUpdate.GegoennterInteger;
            dbGegoennterKunde.BesteBankId = gegoennterKundeUpdate.BesteBankId;
        }

        internal static IGegoennterKunde FromDbGegoennterKunde(IDbGegoennterKunde dbGegoennterKunde)
        {
            return new GegoennterKunde()
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

        internal static IDbGegoennterKunde CreateDbGegoennterKunde(Guid gegoennterKundeId, IGegoennterKundeCreate gegoennterKundeCreate)
        {
            return new DbGegoennterKunde()
            {
                Id = gegoennterKundeId,
                Name = gegoennterKundeCreate.Name,
                GegoennterName = gegoennterKundeCreate.GegoennterName,
                GegoennterBoolean = gegoennterKundeCreate.GegoennterBoolean,
                GegoennterDateTime = gegoennterKundeCreate.GegoennterDateTime,
                GegoennterDouble = gegoennterKundeCreate.GegoennterDouble,
                GegoennterGuid = gegoennterKundeCreate.GegoennterGuid,
                GegoennterInteger = gegoennterKundeCreate.GegoennterInteger,
                BesteBankId = gegoennterKundeCreate.BesteBankId,
            };
        }
    }
}