using Microsoft.EntityFrameworkCore;
using Notebook.Domain.Entities.NoteAggregate;
using Notebook.Infrastructure.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Infrastructure
{
    public class NotebookDbContext: DbContext
    {
        public NotebookDbContext(DbContextOptions<NotebookDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
