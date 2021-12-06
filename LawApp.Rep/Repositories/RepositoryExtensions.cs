using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using LawApp.Common.Models;
using LawApp.Common.Models.Enum;

namespace LawApp.Rep.Repositories
{
    internal static class RepositoryExtensions
    {
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, PagingParameters pageParams)
        {
            return !pageParams.Equals(PagingParameters.Empty) ? query.Skip(pageParams.Skip).Take(pageParams.Take) : query;
        }

        public static IQueryable<T> ApplyPagingAndSortingAnyObject<T>(IQueryable<T> query, PagingParameters pagingParameters,
            SortInfo sortInfo) where T : class
        {
            if (!sortInfo.Equals(SortInfo.Empty))
            {
                Expression<Func<T, object>> sortingExpression = p => EF.Property<object>(p, sortInfo.SortBy);

                switch (sortInfo.Direction)
                {
                    case SortDirection.Asc:
                        query = query.OrderBy(sortingExpression);
                        break;
                    case SortDirection.Desc:
                        query = query.OrderByDescending(sortingExpression);
                        break;
                }
            }
            query = query.ApplyPaging(pagingParameters);

            return query;
        }
    }
}