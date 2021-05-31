using System.Collections.Generic;

namespace Contract.Architecture.Backend.Core.Contract.Contexts
{
    public interface IPaginationContext
    {
        int Limit { get; }

        int Offset { get; }

        IEnumerable<IPaginationFilterItem> Filter { get; }

        IEnumerable<IPaginationSortItem> Sort { get; }
    }
}