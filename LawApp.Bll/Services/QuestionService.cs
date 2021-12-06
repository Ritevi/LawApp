using LawApp.Common.Models.Domain;
using LawApp.Common.Models.Dto;
using LawApp.Common.Repositories;
using LawApp.Common.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LawApp.Bll.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;

        public QuestionService(IQuestionRepository questionRepository, IAnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }

        public async Task<List<Question>> GetFirstQuestionsAsync(QuestionPagingDto context)
        {
            return await _questionRepository.GetFirstQuestionAsync(context);
        }

        public async Task<List<Question>> GetByAnswersAsync(QuestionsByAnswersDto context)
        {
            var answers = await _answerRepository.GetByIdsAsync(context.Answers);
            return await _questionRepository.GetByAnswersAsync(answers, context.PagingParameters);
        }
    }
}
