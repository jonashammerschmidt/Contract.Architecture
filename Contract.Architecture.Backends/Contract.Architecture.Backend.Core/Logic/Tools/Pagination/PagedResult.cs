using Contract.Architecture.Backend.Core.Contract.Logic.Tools.Pagination;
using Contract.Architecture.Backend.Core.Contract.Persistence.Tools.Pagination;
using System;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Logic.Tools.Pagination
{
    internal class PagedResult
    {
        public static IPagedResult<Tout> FromDbPagedResult<Tin, Tout>(
            IDbPagedResult<Tin> dbPagedResult,
            Func<Tin, Tout> dtoTransformation)
        {
            return new PagedResult<Tout>()
            {
                Count = dbPagedResult.Count,
                Limit = dbPagedResult.Limit,
                Offset = dbPagedResult.Offset,
                TotalCount = dbPagedResult.TotalCount,
                Data = dbPagedResult.Data.Select(dtoTransformation),
            };
        }
    }
}