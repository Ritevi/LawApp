using LawApp.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawApp.Common.Models.Domain
{
    public class Tag : IHasId
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}
