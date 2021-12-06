using System.Collections.Generic;
using System.Threading.Tasks;
using LawApp.Common.Models.Domain;

namespace LawApp.Common.Services
{
    public interface IDocService
    {
        Task<List<Doc>> GetByTagsAsync(List<Tag> tags);
    }
}