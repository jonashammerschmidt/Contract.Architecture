using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Bankwesen.Banken;
using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Kundenstamm.Kunden;
using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Kundenstamm.Kunden;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Modules.Kundenstamm.Kunden
{
    internal class KundeDetail : IKundeDetail
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool? Boolean { get; set; }

        public DateTime? DateTime { get; set; }

        public double? Double { get; set; }

        public Guid? Guid { get; set; }

        public int? Integer { get; set; }

        public IBank Bank { get; set; }

        internal static KundeDetail FromDbKundeDetail(IDbKundeDetail dbKundeDetail)
        {
            return new KundeDetail()
            {
                Id = dbKundeDetail.Id,
                Name = dbKundeDetail.Name,
                Boolean = dbKundeDetail.Boolean,
                DateTime = dbKundeDetail.DateTime,
                Double = dbKundeDetail.Double,
                Guid = dbKundeDetail.Guid,
                Integer = dbKundeDetail.Integer,
                Bank = Bankwesen.Banken.Bank.FromDbBank(dbKundeDetail.Bank),
            };
        }
    }
}