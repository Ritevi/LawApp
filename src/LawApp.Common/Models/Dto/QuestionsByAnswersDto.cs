using System;
using System.Collections.Generic;
using LawApp.Common.Models.Domain;

namespace LawApp.Common.Models.Dto
{
    public class QuestionsByAnswersDto
    {
        public PagingParameters PagingParameters { get; set; }
        public List<Guid> Answers { get; set; }
 
    }
}
