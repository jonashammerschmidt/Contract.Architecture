using Contract.Architecture.Backend.Core.Contract.Logic.Services.Identifier;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Services.Identifier
{
    internal class GuidGenerator : IGuidGenerator
    {
        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }
    }
}