using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Modules.GegoennterKundenstamm.GegoennteKunden
{
    internal class GegoennterKundeListItem : IGegoennterKundeListItem
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

        internal static IGegoennterKundeListItem FromDbGegoennterKundeListItem(IDbGegoennterKundeListItem dbGegoennterKundeListItem)
        {
            return new GegoennterKundeListItem()
            {
                Id = dbGegoennterKundeListItem.Id,
                Name = dbGegoennterKundeListItem.Name,
                GegoennterName = dbGegoennterKundeListItem.GegoennterName,
                GegoennterBoolean = dbGegoennterKundeListItem.GegoennterBoolean,
                GegoennterDateTime = dbGegoennterKundeListItem.GegoennterDateTime,
                GegoennterDouble = dbGegoennterKundeListItem.GegoennterDouble,
                GegoennterGuid = dbGegoennterKundeListItem.GegoennterGuid,
                GegoennterInteger = dbGegoennterKundeListItem.GegoennterInteger,
                BesteBank = GegoenntesBankwesen.GegoennteBanken.GegoennteBank.FromDbGegoennteBank(dbGegoennterKundeListItem.BesteBank),
            };
        }
    }
}