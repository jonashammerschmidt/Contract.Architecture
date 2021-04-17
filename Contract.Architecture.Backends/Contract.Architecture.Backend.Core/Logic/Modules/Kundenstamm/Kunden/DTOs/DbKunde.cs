using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Kundenstamm.Kunden;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Modules.Kundenstamm.Kunden
{
    internal class DbKunde : IDbKunde
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public bool? Boolean { get; set; }

        public DateTime? DateTime { get; set; }

        public double? Double { get; set; }

        public Guid? Guid { get; set; }

        public int? Integer { get; set; }

        public Guid BankId { get; set; }
    }
}