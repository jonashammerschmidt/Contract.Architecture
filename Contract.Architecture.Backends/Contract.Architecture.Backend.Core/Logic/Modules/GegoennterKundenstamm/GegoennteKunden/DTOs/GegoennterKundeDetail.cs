using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Modules.GegoennterKundenstamm.GegoennteKunden
{
    internal class GegoennterKundeDetail : IGegoennterKundeDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool? GegoennterBoolean { get; set; }

        public DateTime? GegoennterDateTime { get; set; }

        public double? GegoennterDouble { get; set; }

        public Guid? GegoennterGuid { get; set; }

        public int? GegoennterInteger { get; set; }

        public IGegoennteBank BesteBank { get; set; }

        internal static GegoennterKundeDetail FromDbGegoennterKundeDetail(IDbGegoennterKundeDetail dbGegoennterKundeDetail)
        {
            return new GegoennterKundeDetail()
            {
                Id = dbGegoennterKundeDetail.Id,
                Name = dbGegoennterKundeDetail.Name,
                GegoennterName = dbGegoennterKundeDetail.GegoennterName,
                GegoennterBoolean = dbGegoennterKundeDetail.GegoennterBoolean,
                GegoennterDateTime = dbGegoennterKundeDetail.GegoennterDateTime,
                GegoennterDouble = dbGegoennterKundeDetail.GegoennterDouble,
                GegoennterGuid = dbGegoennterKundeDetail.GegoennterGuid,
                GegoennterInteger = dbGegoennterKundeDetail.GegoennterInteger,
                BesteBank = GegoenntesBankwesen.GegoennteBanken.GegoennteBank.FromDbGegoennteBank(dbGegoennterKundeDetail.BesteBank),
            };
        }
    }
}