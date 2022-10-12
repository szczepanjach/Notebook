using Notebook.Domain.Entities.NoteAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notebook.Domain.Repositories
{
    public interface INoteRepository
    {
        Task<Note> GetById(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Note>> GetAll(CancellationToken cancellationToken);
        Task Create (Note note, CancellationToken cancellationToken);
        Task Update(Note note, CancellationToken cancellationToken);
        Task Delete(int noteId, CancellationToken cancellationToken);
        bool ExistsWithSubject(string subject, int noteId);
    }
}
