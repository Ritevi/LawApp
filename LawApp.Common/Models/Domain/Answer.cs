using LawApp.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawApp.Common.Models.Domain
{
    public class Answer: IHasId
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<Tag> Tags { get; set; }
        public Question Question { get; set; }
        public List<Question> NextQuestions { get; set; }
    }
}
