using System.Collections.Generic;
using System.Threading.Tasks;
using LawApp.Common.Models.Domain;
using LawApp.Common.Repositories;
using LawApp.Common.Services;

namespace LawApp.Bll.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<List<Tag>> GetTagsAsync()
        {
            return await _tagRepository.GetTagsAsync();
        }
    }
}