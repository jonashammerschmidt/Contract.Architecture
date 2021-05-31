using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Contract.Architecture.Backend.Core.Persistence.Tools.Pagination
{
    public static class IQueryableExtension
    {
        /// <summary>
        /// Any mit Like-Vergleichen.
        /// Übersetzung von C# in SQL wie folgt:
        /// C#:
        ///   - propertyName="name"
        ///   - propertyValues=["%01%", "%02%"]
        /// SQL:
        ///   - row.name LIKE "%01%" OR row.name LIKE "%02%"
        /// .
        /// </summary>
        /// <typeparam name="T">Generic für Every-EF-Table.</typeparam>
        /// <param name="query">Abfrageobjekt.</param>
        /// <param name="propertyName">Name der Tabellenspalte die für den Vergleich genutzt werden soll.</param>
        /// <param name="propertyValues">Werte, die verglichen werden sollen.</param>
        /// <returns>Abfrageobjekt + Vergleich.</returns>
        public static IQueryable<T> LikeAny<T>(this IQueryable<T> query, string propertyName, params string[] propertyValues)
        {
            var parameter = Expression.Parameter(typeof(T));

            var body = propertyValues
                .Select(word => Expression.Call(
                    typeof(DbFunctionsExtensions).GetMethod(
                        nameof(DbFunctionsExtensions.Like),
                        new[] { typeof(DbFunctions), typeof(string), typeof(string) }),
                    Expression.Constant(EF.Functions),
                    Expression.Property(parameter, typeof(T).GetProperty(propertyName)),
                    Expression.Constant(word)))
                .Aggregate<MethodCallExpression, Expression>(
                    null,
                    (current, call) => current != null ? Expression.OrElse(current, call) : (Expression)call);

            return query.Where(Expression.Lambda<Func<T, bool>>(body, parameter));
        }
    }
}