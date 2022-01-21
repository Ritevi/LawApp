using LawApp.Common.Models.Domain;
using LawApp.Common.Repositories;
using LawApp.Rep.SqlContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawApp.Rep.Repositories
{
    class AnswerRepository : ItemHasIdRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(IAppContextFactory hubContextFactory) : base(hubContextFactory)
        {
            
        }

        public override async Task<List<Answer>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            return await dbFactory.CreateContext().Answers
                .Where(item => ids.Contains(item.Id))
                .Include(x => x.NextQuestions)
                .ToListAsync();
        }
    }
}
