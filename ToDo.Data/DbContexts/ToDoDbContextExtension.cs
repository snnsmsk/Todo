using System;
using System.Linq;
using System.Reflection;
using System.Text;
using ToDo.Api.Model;
using System.Linq.Dynamic.Core;
using ToDo.Data.Model;
using System.Linq.Expressions;

namespace ToDo.Data.DbContexts
{
    public static class ToDoDbContextExtension
    {
        public static IQueryable<TEntity> OrderByExt<TEntity>(this IQueryable<TEntity> queryable, SearchDto searchDto
            ) where TEntity : class
        {

            if (searchDto == null)
                return queryable;

            return OrderByExt(queryable, searchDto.OrderBy);
        }


        public static IQueryable<TEntity> OrderByExt<TEntity>(this IQueryable<TEntity> queryable, string orderByQueryString
            ) where TEntity : class
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return queryable;
            }

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name} {sortingOrder}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return string.IsNullOrWhiteSpace(orderQuery) ? queryable : queryable.OrderBy(orderQuery);
        }

        public static IQueryable<TEntity> WhereNotDeleted<TEntity>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, bool>> predicate)
         where TEntity : ToDoEntity
        {
            return queryable.Where(m => !m.Deleted).Where(predicate);
        }
    }
}
