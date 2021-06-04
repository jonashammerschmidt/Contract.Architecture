using Contract.Architecture.Backend.Core.Contract.Contexts;
using Contract.Architecture.Backend.Core.Contract.Persistence.Tools.Pagination;
using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.Logic.Tests.Tools.Pagination
{
    internal class DbPagedResult<T> : IDbPagedResult<T>
    {
        public int Count { get; set; }

        public IEnumerable<T> Data { get; set; }

        public int Limit { get; set; }

        public int Offset { get; set; }

        public int TotalCount { get; set; }
    }
}