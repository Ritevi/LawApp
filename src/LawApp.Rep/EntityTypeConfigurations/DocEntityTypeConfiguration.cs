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
    class DocEntityTypeConfiguration : IEntityTypeConfiguration<Doc>
    {
        public void Configure(EntityTypeBuilder<Doc> builder)
        {
            builder.HasMany(x => x.Tags).WithMany(x => x.Docs);
        }
    }
}
