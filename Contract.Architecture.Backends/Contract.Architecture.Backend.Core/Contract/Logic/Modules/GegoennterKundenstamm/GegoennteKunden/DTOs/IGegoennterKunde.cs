using System;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Modules.GegoennterKundenstamm.GegoennteKunden
{
    public interface IGegoennterKunde
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string GegoennterName { get; set; }

        bool? GegoennterBoolean { get; set; }

        DateTime? GegoennterDateTime { get; set; }

        double? GegoennterDouble { get; set; }

        Guid? GegoennterGuid { get; set; }

        int? GegoennterInteger { get; set; }

        Guid BesteBankId { get; set; }
    }
}