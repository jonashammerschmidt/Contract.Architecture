using Contract.Architecture.Backend.Core.Contract.Logic.Modules.Bankwesen.Banken;
using System;
using System.ComponentModel.DataAnnotations;

namespace Contract.Architecture.Backend.Core.API.Modules.Bankwesen.Banken
{
    public class BankCreate : IBankCreate
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        public bool Boolean { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public double Double { get; set; }

        [Required]
        public Guid Guid { get; set; }

        [Required]
        public int Integer { get; set; }
    }
}