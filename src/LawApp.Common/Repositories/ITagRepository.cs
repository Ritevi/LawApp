using System.Collections.Generic;
using System.Threading.Tasks;
using LawApp.Common.Models.Domain;

namespace LawApp.Common.Repositories
{
    public interface ITagRepository : IHasIdRepository<Tag>
    {
        public Task<List<Tag>> GetTagsAsync();
    }
}