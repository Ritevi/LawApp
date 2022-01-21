using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using LawApp.Common.Models;

namespace LawApp.Common.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<int> GetCountAsync();
        Task<List<T>> GetItemsAsync(PagingParameters pagingParameters);
        Task<bool> AnyAsync();
        Task<T> AddAsync(T item);
        Task AddRangeAsync(IEnumerable<T> item);
        Task<List<T>> GetAllAsync();
    }
}
