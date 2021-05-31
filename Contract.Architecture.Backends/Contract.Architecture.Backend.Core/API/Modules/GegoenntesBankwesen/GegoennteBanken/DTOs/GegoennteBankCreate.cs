using Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken;
using System;
using System.ComponentModel.DataAnnotations;

namespace Contract.Architecture.Backend.Core.API.Modules.GegoenntesBankwesen.GegoennteBanken
{
    public class GegoennteBankCreate : IGegoennteBankCreate
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string GegoennterName { get; set; }

        [Required]
        public bool GegoennterBoolean { get; set; }

        [Required]
        public DateTime GegoenntesDateTime { get; set; }

        [Required]
        public double GegoennterDouble { get; set; }

        [Required]
        public Guid GegoennteGuid { get; set; }

        [Required]
        public int GegoennterInteger { get; set; }
    }
}