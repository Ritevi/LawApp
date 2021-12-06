using System.Collections.Generic;
using System.Threading.Tasks;
using LawApp.Common.Models.Domain;

namespace LawApp.Common.Repositories
{
    public interface IDocRepository : IHasIdRepository<Doc>
    {
        public Task<List<Doc>> GetByTags(List<Tag> tags);
    }
}
