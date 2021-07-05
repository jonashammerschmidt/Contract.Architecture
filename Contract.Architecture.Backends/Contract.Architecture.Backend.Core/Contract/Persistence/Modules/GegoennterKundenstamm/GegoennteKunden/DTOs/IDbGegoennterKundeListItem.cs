using Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken;
using System;

namespace Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoennterKundenstamm.GegoennteKunden
{
    public interface IDbGegoennterKundeListItem
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string GegoennterName { get; set; }

        bool? GegoennterBoolean { get; set; }

        DateTime? GegoennterDateTime { get; set; }

        double? GegoennterDouble { get; set; }

        Guid? GegoennterGuid { get; set; }

        int? GegoennterInteger { get; set; }

        IDbGegoennteBank BesteBank { get; set; }
    }
}