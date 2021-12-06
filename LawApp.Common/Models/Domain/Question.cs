using LawApp.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawApp.Common.Models.Domain
{
    public class Question : IHasId
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Tag> Tags { get; set; } //todo maybe remove, because 'yes' answer contains default tag for this question
        public int CategoryNumber { get; set; }

        public Answer PreviousAnswer { get; set; }
    }
}
