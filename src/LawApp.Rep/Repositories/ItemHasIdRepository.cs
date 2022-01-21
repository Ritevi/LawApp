using LawApp.Common.Models;
using LawApp.Common.Models.Interfaces;
using LawApp.Common.Repositories;
using LawApp.Rep.SqlContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawApp.Rep.Repositories
{ 
    class ItemHasIdRepository<T> : BaseRepository<T>, IHasIdRepository<T> where T : class, IHasId
    {
        public ItemHasIdRepository(IAppContextFactory hubContextFactory) : base(hubContextFactory) { }


        public async virtual Task<T> GetItemByIdAsync(Guid id)
        {
            return await dbFactory.CreateContext().Set<T>().FirstAsync(item => item.Id == id);
        }

        public async virtual Task<bool> ExistsAsync(Guid id)
        {
            return await dbFactory.CreateContext().Set<T>().AnyAsync(item => item.Id == id);
        }

        public async virtual Task<List<T>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            return await dbFactory.CreateContext().Set<T>()
                .Where(item => ids.Contains(item.Id))
                .ToListAsync();
        }

        public async virtual Task<List<Guid>> GetIdsAsync(PagingParameters pagingParameters)
        {
            return await dbFactory.CreateContext()
                .Set<T>()
                .Skip(pagingParameters.Skip)
                .Take(pagingParameters.Take)
                .Select(n => n.Id)
                .ToListAsync();
        }
    }
}