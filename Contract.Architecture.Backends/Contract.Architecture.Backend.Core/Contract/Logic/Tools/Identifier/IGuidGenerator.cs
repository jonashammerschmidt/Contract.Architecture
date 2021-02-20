using System;

namespace Contract.Architecture.Backend.Core.Contract.Logic.Tools.Identifier
{
    public interface IGuidGenerator
    {
        Guid NewGuid();
    }
}