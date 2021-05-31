using Contract.Architecture.Backend.Core.Contract.Contexts;
using Contract.Architecture.Backend.Core.Contract.Persistence.Tools.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Contract.Architecture.Backend.Core.Persistence.Tools.Pagination
{
    public static class Pagination
    {
        public static IDbPagedResult<Tout> Filter<Tin, Tout>(
            IQueryable<Tin> query,
            IPaginationContext paginationContext,
            Func<Tin, Tout> dtoTransformation)
        {
            try
            {
                query = Filtering(query, paginationContext);
                query = Sorting(query, paginationContext);

                int totalCount = query.Count();
                query = query.Skip(paginationContext.Offset);
                query = query.Take(paginationContext.Limit);

                return new DbPagedResult<Tout>(paginationContext)
                {
                    Count = query.Count(),
                    Data = query.Select(dtoTransformation),
                    TotalCount = totalCount,
                };
            }
            catch
            {
                throw new PaginationException();
            }
        }

        private static IQueryable<Tin> Filtering<Tin>(IQueryable<Tin> query, IPaginationContext paginationContext)
        {
            foreach (var filterElement in paginationContext.Filter)
            {
                string propertyName = char.ToUpper(filterElement.PropertyName[0]) + filterElement.PropertyName[1..];
                string[] propertyValueSplit = filterElement.PropertyValue.Split('|');

                if (Guid.TryParse(propertyValueSplit[0], out Guid propertyValueGuid))
                {
                    var propertyValueGuids = propertyValueSplit.Select(propertyValue => Guid.Parse(propertyValue));
                    query = query.Where(p => propertyValueGuids.Contains(EF.Property<Guid>(p, propertyName)));
                }
                else if (int.TryParse(propertyValueSplit[0], out int propertyValueInt))
                {
                    switch (filterElement.FilterType)
                    {
                        case FilterType.GreaterThan:
                            query = query.Where(p => EF.Property<int>(p, propertyName) > propertyValueInt);
                            break;

                        case FilterType.GreaterThanOrEqual:
                            query = query.Where(p => EF.Property<int>(p, propertyName) >= propertyValueInt);
                            break;

                        case FilterType.LessThan:
                            query = query.Where(p => EF.Property<int>(p, propertyName) < propertyValueInt);
                            break;

                        case FilterType.LessThanOrEqual:
                            query = query.Where(p => EF.Property<int>(p, propertyName) <= propertyValueInt);
                            break;

                        case FilterType.Equal:
                        default:
                            var propertyValueIntegers = propertyValueSplit.Select(propertyValue => int.Parse(propertyValue));
                            query = query.Where(p => propertyValueIntegers.Contains(EF.Property<int>(p, propertyName)));
                            break;
                    }
                }
                else if (double.TryParse(propertyValueSplit[0], out double propertyValueDouble))
                {
                    switch (filterElement.FilterType)
                    {
                        case FilterType.GreaterThan:
                            query = query.Where(p => EF.Property<double>(p, propertyName) > propertyValueDouble);
                            break;

                        case FilterType.GreaterThanOrEqual:
                            query = query.Where(p => EF.Property<double>(p, propertyName) >= propertyValueDouble);
                            break;

                        case FilterType.LessThan:
                            query = query.Where(p => EF.Property<double>(p, propertyName) < propertyValueDouble);
                            break;

                        case FilterType.LessThanOrEqual:
                            query = query.Where(p => EF.Property<double>(p, propertyName) <= propertyValueDouble);
                            break;

                        case FilterType.Equal:
                        default:
                            var propertyValueDoubles = propertyValueSplit.Select(propertyValue => double.Parse(propertyValue));
                            query = query.Where(p => propertyValueDoubles.Contains(EF.Property<double>(p, propertyName)));
                            break;
                    }
                }
                else if (bool.TryParse(propertyValueSplit[0], out bool propertyValueBool))
                {
                    query = query.Where(p => EF.Property<bool>(p, propertyName) == propertyValueBool);
                }
                else if (DateTime.TryParse(propertyValueSplit[0], out DateTime propertyValueDateTime))
                {
                    switch (filterElement.FilterType)
                    {
                        case FilterType.GreaterThan:
                            query = query.Where(p => EF.Property<DateTime>(p, propertyName) > propertyValueDateTime);
                            break;

                        case FilterType.GreaterThanOrEqual:
                            query = query.Where(p => EF.Property<DateTime>(p, propertyName) >= propertyValueDateTime);
                            break;

                        case FilterType.LessThan:
                            query = query.Where(p => EF.Property<DateTime>(p, propertyName) < propertyValueDateTime);
                            break;

                        case FilterType.LessThanOrEqual:
                            query = query.Where(p => EF.Property<DateTime>(p, propertyName) <= propertyValueDateTime);
                            break;

                        case FilterType.Equal:
                        default:
                            var propertyValueDateTimes = propertyValueSplit.Select(propertyValue => DateTime.Parse(propertyValue));
                            query = query.Where(p => propertyValueDateTimes.Contains(EF.Property<DateTime>(p, propertyName)));
                            break;
                    }
                }
                else
                {
                    query = query.LikeAny(propertyName, propertyValueSplit);
                }
            }

            return query;
        }

        private static IQueryable<Tin> Sorting<Tin>(IQueryable<Tin> query, IPaginationContext paginationContext)
        {
            var sort = paginationContext.Sort;
            for (int i = 0; i < sort.Count(); i++)
            {
                var sortElement = sort.ElementAt(i);
                string propertyName = char.ToUpper(sortElement.PropertyName[0]) + sortElement.PropertyName[1..];
                if (i == 0)
                {
                    if (sortElement.OrderBy == SortOrder.ASC)
                    {
                        query = query.OrderBy(p => EF.Property<object>(p, propertyName));
                    }
                    else
                    {
                        query = query.OrderByDescending(p => EF.Property<object>(p, propertyName));
                    }
                }
                else
                {
                    var orderedQuery = query as IOrderedQueryable<Tin>;

                    if (sortElement.OrderBy == SortOrder.ASC)
                    {
                        query = orderedQuery.ThenBy(p => EF.Property<object>(p, propertyName));
                    }
                    else
                    {
                        query = orderedQuery.ThenByDescending(p => EF.Property<object>(p, propertyName));
                    }
                }
            }

            return query;
        }
    }
}