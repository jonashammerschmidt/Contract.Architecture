using System;

namespace Contract.Architecture.Backend.Core.Contract.Persistence.Modules.Bankwesen.Banken
{
    public interface IDbBank
    {
        Guid Id { get; set; }

        string Name { get; set; }

        bool Boolean { get; set; }

        DateTime DateTime { get; set; }

        double Double { get; set; }

        Guid Guid { get; set; }

        int Integer { get; set; }
    }
}