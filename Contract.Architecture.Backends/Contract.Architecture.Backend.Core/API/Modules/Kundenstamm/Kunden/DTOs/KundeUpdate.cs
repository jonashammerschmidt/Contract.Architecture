using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Kundenstamm.Kunden;
using System;
using System.ComponentModel.DataAnnotations;

namespace Contract.Architecture.Backend.Core.API.Modules.Kundenstamm.Kunden
{
    public class KundeUpdate : IKundeUpdate
    {
        [Required]
        public Guid Id { get; set; }

        [StringLength(256)]
        public string? Name { get; set; }

        public bool? Boolean { get; set; }

        public DateTime? DateTime { get; set; }

        public double? Double { get; set; }

        public Guid? Guid { get; set; }

        public int? Integer { get; set; }

        [Required]
        public Guid BankId { get; set; }
    }
}