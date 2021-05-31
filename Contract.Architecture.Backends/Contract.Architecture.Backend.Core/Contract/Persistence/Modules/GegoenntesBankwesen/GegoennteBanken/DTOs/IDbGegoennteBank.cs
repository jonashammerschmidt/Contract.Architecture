using System;

namespace Contract.Architecture.Backend.Core.Contract.Persistence.Modules.GegoenntesBankwesen.GegoennteBanken
{
    public interface IDbGegoennteBank
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string GegoennterName { get; set; }

        bool GegoennterBoolean { get; set; }

        DateTime GegoenntesDateTime { get; set; }

        double GegoennterDouble { get; set; }

        Guid GegoennteGuid { get; set; }

        int GegoennterInteger { get; set; }
    }
}