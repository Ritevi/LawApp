using LawApp.Common.Models.Enum;
using LawApp.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawApp.Common.Models.Domain
{
    public class Doc : IHasId
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Tag> Tags { get; set; }
        public DocType Type { get; set; }
    }
}
