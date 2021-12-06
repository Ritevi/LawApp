using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawApp.Common.Models.Domain;
using LawApp.Common.Repositories;
using LawApp.Rep.SqlContext;
using Microsoft.EntityFrameworkCore;

namespace LawApp.Rep.Repositories
{
    class DocRepository : ItemHasIdRepository<Doc>, IDocRepository
    {
        public DocRepository(IAppContextFactory hubContextFactory) : base(hubContextFactory)
        {
        }

        public async Task<List<Doc>> GetByTags(List<Tag> tags)
        {
            var dbContext = dbFactory.CreateContext();

            return await dbContext.Docs.Where(doc => doc.Tags.Union(tags).Any()).ToListAsync();
        }
    }
}
