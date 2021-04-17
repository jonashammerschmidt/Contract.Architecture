using Contract.Architecture.Backend.Core.Persistence.Modules.Bankwesen.Banken;
using System;

namespace Contract.Architecture.Backend.Core.Persistence.Modules.Kundenstamm.Kunden
{
    public class EfKunde
    {
        public EfKunde()
        {
        }

        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool? Boolean { get; set; }

        public DateTime? DateTime { get; set; }

        public double? Double { get; set; }

        public Guid? Guid { get; set; }

        public int? Integer { get; set; }

        public Guid BankId { get; set; }

        public virtual EfBank Bank { get; set; }
    }
}