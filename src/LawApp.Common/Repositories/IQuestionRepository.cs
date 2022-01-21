using LawApp.Common.Models;
using LawApp.Common.Models.Domain;
using LawApp.Common.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LawApp.Common.Repositories
{
    public interface IQuestionRepository : IHasIdRepository<Question>
    {
        public Task<List<Question>> GetByAnswersAsync(List<Answer> answers, PagingParameters paging);

        public Task<List<Question>> GetFirstQuestionsAsync(QuestionPagingDto context);
    }
}
