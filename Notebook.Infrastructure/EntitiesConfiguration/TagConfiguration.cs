using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notebook.Domain.Entities.NoteAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Infrastructure.EntitiesConfiguration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.TagValue).HasMaxLength(20).IsRequired();
            builder.Property(p => p.NoteId).IsRequired();
        }
    }
}
