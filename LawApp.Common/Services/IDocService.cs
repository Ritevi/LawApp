using System.Collections.Generic;
using System.Threading.Tasks;
using LawApp.Common.Models.Dto;

namespace LawApp.Common.Services
{
    public interface IDocService
    {
        Task<List<DocViewModel>> GetByTagsAsync(List<TagViewModel> tags);
        Task<List<DocViewModel>> GetByTagAsync(string tag);

    }
}