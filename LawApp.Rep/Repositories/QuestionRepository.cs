using LawApp.Common.Models;
using LawApp.Common.Models.Domain;
using LawApp.Common.Models.Dto;
using LawApp.Common.Repositories;
using LawApp.Rep.SqlContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawApp.Rep.Repositories
{
    internal class QuestionRepository : ItemHasIdRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(IAppContextFactory hubContextFactory) : base(hubContextFactory)
        {
        }


        public async Task<List<Question>> GetFirstQuestionAsync(QuestionPagingDto context)
        {
            var dbContext = dbFactory.CreateContext();

            var query = dbContext.Questions.Where(x => x.CategoryNumber == 1)
                .Include(x => x.Answers)
                .ThenInclude(x => x.NextQuestions)
                .Include(x => x.Answers)
                .ThenInclude(x => x.Tags);

            return await query.ApplyPaging(context.PagingParameters).ToListAsync();
        }

        public async Task<List<Question>> GetByAnswersAsync(List<Answer> answers, PagingParameters paging)
        {
            var dbContext = dbFactory.CreateContext();

            var questionIds = answers.SelectMany(x=>x.NextQuestions).Select(x=>x.Id).ToList();
            var query = dbContext.Questions.Where(q => questionIds.Contains(q.Id))
                .Include(x => x.Answers)
                .ThenInclude(x => x.NextQuestions)
                .Include(x => x.Answers)
                .ThenInclude(x => x.Tags);
                

            return await query.ApplyPaging(paging).ToListAsync();
        }
    }
}
