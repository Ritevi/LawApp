using LawApp.Common.Models.Domain;
using LawApp.Common.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using LawApp.Common.Services;

namespace LawApp.Bll.Services
{
    class DocService : IDocService
    {
        private readonly IDocRepository _docRepository;

        public DocService(IDocRepository docRepository)
        {
            _docRepository = docRepository;
        }

        public async Task<List<Doc>> GetByTagsAsync(List<Tag> tags)
        {
            return await _docRepository.GetByTags(tags);
        }
    }
}
