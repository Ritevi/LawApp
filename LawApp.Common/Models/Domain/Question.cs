using LawApp.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using LawApp.Common.Models.Enum;

namespace LawApp.Common.Models.Domain
{
    public class Question : IHasId
    {
        public Guid Id { get; set; }
        public QuestionType Type { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Tag> Tags { get; set; } 
        public int CategoryNumber { get; set; }
        public Answer PreviousAnswer { get; set; }
    }
}
