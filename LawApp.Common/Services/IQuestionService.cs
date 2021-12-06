using System.Collections.Generic;
using System.Threading.Tasks;
using LawApp.Common.Models.Domain;
using LawApp.Common.Models.Dto;

namespace LawApp.Common.Services
{
    public interface IQuestionService
    {
        Task<List<Question>> GetFirstQuestionsAsync(QuestionPagingDto context);
        Task<List<Question>> GetByAnswersAsync(QuestionsByAnswersDto context);
    }
}