using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken;
using System;

namespace Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Kundenstamm.Kunden
{
    public interface IDbKundeDetail
    {
        Guid Id { get; set; }

        string? Name { get; set; }

        bool? Boolean { get; set; }

        DateTime? DateTime { get; set; }

        double? Double { get; set; }

        Guid? Guid { get; set; }

        int? Integer { get; set; }

        IDbBank Bank { get; set; }
    }
}