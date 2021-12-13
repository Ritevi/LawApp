using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawApp.Common.Models.Domain;
using LawApp.Common.Models.Dto;
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

        public async Task<List<Doc>> GetByTagsAsync(List<TagViewModel> tags)
        {
            var dbContext = dbFactory.CreateContext();

            var tagIds = tags.Select(x => x.Id).ToList();
            return await dbContext.Docs.Include(d=>d.Tags)
                .Where(doc => doc.Tags.Intersect(
                    dbContext.Tags.Where(x=>tagIds.Contains(x.Id)))
                    .Any())
                .ToListAsync();
        }
        
        public async Task<List<Doc>> GetByTagAsync(string tag)
        {
            var dbContext = dbFactory.CreateContext();
            
            return await dbContext.Docs.Include(d=>d.Tags)
                .Where(doc => doc.Tags.Any(t=>t.Text.ToLower().Equals(tag.ToLower())))
                .ToListAsync();
        }
    }
}
