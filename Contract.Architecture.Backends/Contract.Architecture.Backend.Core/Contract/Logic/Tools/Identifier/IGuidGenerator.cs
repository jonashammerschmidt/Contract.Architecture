using System;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Services.Identifier
{
    public interface IGuidGenerator
    {
        Guid NewGuid();
    }
}