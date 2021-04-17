using Contract.Architecture.Backend.Core.Persistence.Modules.Kundenstamm.Kunden;
using System;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.Bankwesen.Banken
{
    public class EfBank
    {
        public EfBank()
        {
            this.Kunden = new HashSet<EfKunde>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Boolean { get; set; }

        public DateTime DateTime { get; set; }

        public double Double { get; set; }

        public Guid Guid { get; set; }

        public int Integer { get; set; }

        public virtual ICollection<EfKunde> Kunden { get; set; }
    }
}