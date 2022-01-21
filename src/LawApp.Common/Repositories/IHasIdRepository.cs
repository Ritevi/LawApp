using LawApp.Common.Models;
using LawApp.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LawApp.Common.Repositories
{
    public interface IHasIdRepository<T> : IRepository<T> where T : class, IHasId
    {
        Task<T> GetItemByIdAsync(Guid id);

        Task<bool> ExistsAsync(Guid id);

        Task<List<T>> GetByIdsAsync(IEnumerable<Guid> ids);

        Task<List<Guid>> GetIdsAsync(PagingParameters pagingParameters);
    }
}