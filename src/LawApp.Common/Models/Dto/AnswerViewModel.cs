using System;
using System.Collections.Generic;

namespace LawApp.Common.Models.Dto
{
    public class AnswerViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<TagViewModel> Tags { get; set; }

    }
}
