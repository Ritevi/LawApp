using System.Collections.Generic;
using System.Threading.Tasks;
using LawApp.Common.Models.Domain;
using LawApp.Common.Models.Dto;

namespace LawApp.Common.Repositories
{
    public interface IDocRepository : IHasIdRepository<Doc>
    {
        public Task<List<Doc>> GetByTagsAsync(List<TagViewModel> tags);
        public Task<List<Doc>> GetByTagAsync(string tag);
    }
}
