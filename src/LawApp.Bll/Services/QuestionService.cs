using LawApp.Common.Models.Domain;
using LawApp.Common.Models.Dto;
using LawApp.Common.Repositories;
using LawApp.Common.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace LawApp.Bll.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IAnswerRepository answerRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<List<QuestionViewModel>> GetFirstQuestionsAsync(QuestionPagingDto context)
        {
            var questions = await _questionRepository.GetFirstQuestionsAsync(context);
            return _mapper.Map<List<QuestionViewModel>>(questions);
        }

        public async Task<List<QuestionViewModel>> GetByAnswersAsync(QuestionsByAnswersDto context)
        {
            var answers = await _answerRepository.GetByIdsAsync(context.Answers);
            var questions = await _questionRepository.GetByAnswersAsync(answers, context.PagingParameters);
            return _mapper.Map<List<QuestionViewModel>>(questions);
        }
    }
}
