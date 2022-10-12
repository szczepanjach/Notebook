using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notebook.Domain.Entities.NoteAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Infrastructure.EntitiesConfiguration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Subject).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Body).HasMaxLength(2000).IsRequired();
            builder.Metadata.FindNavigation(nameof(Note.Tags))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
