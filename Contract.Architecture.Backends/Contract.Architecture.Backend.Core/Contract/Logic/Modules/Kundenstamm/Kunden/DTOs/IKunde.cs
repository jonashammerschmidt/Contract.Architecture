using System;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.Kundenstamm.Kunden
{
    public interface IKunde
    {
        Guid Id { get; set; }

        string? Name { get; set; }

        bool? Boolean { get; set; }

        DateTime? DateTime { get; set; }

        double? Double { get; set; }

        Guid? Guid { get; set; }

        int? Integer { get; set; }

        Guid BankId { get; set; }
    }
}