using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawApp.Common.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LawApp.Rep.EntityTypeConfigurations
{
    class AnswerEntityTypeConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Tags);
            builder.HasMany(x => x.NextQuestions).WithOne(x => x.PreviousAnswer);
        }
    }
}
