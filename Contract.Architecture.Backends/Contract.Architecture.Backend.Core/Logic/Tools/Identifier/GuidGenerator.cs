﻿using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Identifier;
using System;

namespace Contract.Architecture.Backend.Core.Logic.Tools.Identifier
{
    internal class GuidGenerator : IGuidGenerator
    {
        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }
    }
}