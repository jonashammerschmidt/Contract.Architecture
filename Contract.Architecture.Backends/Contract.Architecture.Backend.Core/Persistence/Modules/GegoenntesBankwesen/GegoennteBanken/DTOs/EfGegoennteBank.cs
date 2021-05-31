using Contract.Architecture.Backend.Core.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden;
using System;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken
{
    public class EfGegoennteBank
    {
        public EfGegoennteBank()
        {
            this.BesteKunden = new HashSet<EfGegoennterKunde>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string GegoennterName { get; set; }

        public bool GegoennterBoolean { get; set; }

        public DateTime GegoenntesDateTime { get; set; }

        public double GegoennterDouble { get; set; }

        public Guid GegoennteGuid { get; set; }

        public int GegoennterInteger { get; set; }

        public virtual ICollection<EfGegoennterKunde> BesteKunden { get; set; }
    }
}