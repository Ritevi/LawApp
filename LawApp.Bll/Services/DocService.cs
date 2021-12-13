using LawApp.Common.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LawApp.Common.Models.Dto;
using LawApp.Common.Services;

namespace LawApp.Bll.Services
{
    class DocService : IDocService
    {
        private readonly IDocRepository _docRepository;
        private readonly IMapper _mapper;

        public DocService(IDocRepository docRepository, IMapper mapper)
        {
            _docRepository = docRepository;
            _mapper = mapper;
        }

        public async Task<List<DocViewModel>> GetByTagsAsync(List<TagViewModel> tags)
        {
            var docList = await _docRepository.GetByTagsAsync(tags);
            return _mapper.Map<List<DocViewModel>>(docList);
        }
        
        public async Task<List<DocViewModel>> GetByTagAsync(string tag)
        {
            var docList = await _docRepository.GetByTagAsync(tag);
            return _mapper.Map<List<DocViewModel>>(docList);
        }
    }
}
