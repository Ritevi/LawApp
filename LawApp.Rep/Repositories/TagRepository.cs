using System.Collections.Generic;
using System.Threading.Tasks;
using LawApp.Common.Models.Domain;
using LawApp.Common.Repositories;
using LawApp.Rep.SqlContext;
using Microsoft.EntityFrameworkCore;

namespace LawApp.Rep.Repositories
{
    class TagRepository : ItemHasIdRepository<Tag>, ITagRepository
    {
        public TagRepository(IAppContextFactory hubContextFactory) : base(hubContextFactory)
        {
        }

        public async Task<List<Tag>> GetTagsAsync()
        {
            var dbContext = dbFactory.CreateContext();
            
            return await dbContext.Tags.Include(t=>t.Docs).ToListAsync();
        }
    }
}