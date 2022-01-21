using System.Collections.Generic;
using System.Threading.Tasks;
using LawApp.Common.Models.Domain;

namespace LawApp.Common.Services
{
    public interface ITagService
    {
        Task<List<Tag>> GetTagsAsync();
    }
}