using System;
using System.Collections.Generic;

namespace LawApp.Common.Models.Dto
{
    public class QuestionViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
        public QuestionViewModel PreviousQuestion { get; set; }

    }
}
