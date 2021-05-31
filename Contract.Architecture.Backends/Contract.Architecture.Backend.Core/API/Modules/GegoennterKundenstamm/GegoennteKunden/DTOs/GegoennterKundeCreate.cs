using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden;
using System;
using System.ComponentModel.DataAnnotations;

namespace Contract.Architecture.Backend.Core.API.Modules.GegoennterKundenstamm.GegoennteKunden
{
    public class GegoennterKundeCreate : IGegoennterKundeCreate
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string GegoennterName { get; set; }

        public bool? GegoennterBoolean { get; set; }

        public DateTime? GegoennterDateTime { get; set; }

        public double? GegoennterDouble { get; set; }

        public Guid? GegoennterGuid { get; set; }

        public int? GegoennterInteger { get; set; }

        [Required]
        public Guid BesteBankId { get; set; }
    }
}