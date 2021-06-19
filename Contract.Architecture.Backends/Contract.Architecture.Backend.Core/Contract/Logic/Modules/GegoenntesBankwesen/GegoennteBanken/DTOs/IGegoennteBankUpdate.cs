using System;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoenntesBankwesen.GegoennteBanken
{
    public interface IGegoennteBankUpdate
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