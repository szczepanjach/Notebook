using Microsoft.EntityFrameworkCore;
using Notebook.Domain.Entities.NoteAggregate;
using Notebook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notebook.Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly NotebookDbContext notebookDbContext;

        public NoteRepository(NotebookDbContext notebookDbContext)
        {
            this.notebookDbContext = notebookDbContext;
        }

        public async Task Create(Note note, CancellationToken cancellationToken)
        {
            await notebookDbContext.Notes.AddAsync(note, cancellationToken);
            await notebookDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int noteId, CancellationToken cancellationToken)
        {
            var noteToDelete = await notebookDbContext.Notes.FirstAsync(n=>n.Id == noteId);
            notebookDbContext.Notes.Remove(noteToDelete);
            await notebookDbContext.SaveChangesAsync(cancellationToken);
        }

        public bool ExistsWithSubject(string subject, int noteId)
        {
            return notebookDbContext.Notes.Any(a => a.Subject == subject && a.Id != noteId);
        }

        public async Task<IEnumerable<Note>> GetAll(CancellationToken cancellationToken)
        {
            return await notebookDbContext.Notes.ToListAsync(cancellationToken);
        }

        public async Task<Note> GetById(int id, CancellationToken cancellationToken)
        {
            return await notebookDbContext.Notes.Include(n=>n.Tags).FirstOrDefaultAsync(n => n.Id == id, cancellationToken);
        }

        public async Task Update(Note note, CancellationToken cancellationToken)
        {
            notebookDbContext.Notes.Attach(note);
            notebookDbContext.Entry(note).State = EntityState.Modified;
            await notebookDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
