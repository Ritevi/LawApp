using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;
using LawApp.Rep.SqlContext;
using LawApp.Common.Models;
using LawApp.Common.Models.Enum;
using LawApp.Common.Repositories;

namespace LawApp.Rep.Repositories
{
    internal class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly IAppContextFactory dbFactory;

        public BaseRepository(IAppContextFactory ContextFactory)
        {
            dbFactory = ContextFactory;
        }

        protected virtual Dictionary<string, Expression<Func<T, object>>> NestedSortingDictionary { get; }

        protected IQueryable<T> ApplyPagingAndSorting(IQueryable<T> query, PagingParameters pageParams, SortInfo sortInfo)
        {
            if (!sortInfo.Equals(SortInfo.Empty))
            {
                Expression<Func<T, object>> sortingExpression = p => EF.Property<object>(p, sortInfo.SortBy);
                if (NestedSortingDictionary != null && NestedSortingDictionary.ContainsKey(sortInfo.SortBy))
                {
                    sortingExpression = NestedSortingDictionary[sortInfo.SortBy];
                }

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

            query = query.ApplyPaging(pageParams);
            return query;
        }

        public async virtual Task<int> GetCountAsync()
        {
            return await dbFactory.CreateContext().Set<T>().CountAsync();
        }

        public async virtual Task<List<T>> GetItemsAsync(PagingParameters pagingParameters)
        {
            return await dbFactory.CreateContext().Set<T>()
                .Skip(pagingParameters.Skip)
                .Take(pagingParameters.Take)
                .ToListAsync();
        }

        public async virtual Task<T> AddAsync(T item)
        {
            var dbContext = dbFactory.CreateContext();
            dbContext.Add(item);
            await dbContext.SaveChangesAsync();
            return item;
        }

        public async virtual Task AddRangeAsync(IEnumerable<T> item)
        {
            var dbContext = dbFactory.CreateContext();
            await dbContext.Set<T>().AddRangeAsync(item);
            await dbContext.SaveChangesAsync();
        }

        public virtual Task<List<T>> GetAllAsync()
        {
            return dbFactory.CreateContext().Set<T>().ToListAsync();
        }

        public async virtual Task<bool> AnyAsync()
        {
            var dbContext = dbFactory.CreateContext();
            return await dbContext.Set<T>().AnyAsync();
        }

        protected virtual Task ExecuteFromFileAsync(string filePath)
        {
            var dbContext = dbFactory.CreateContext();
            var commandText = File.ReadAllText(filePath);
            return dbContext.Database.ExecuteSqlRawAsync(commandText);
        }
    }
}