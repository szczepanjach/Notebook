using MediatR;
using Notebook.Application.CreateNote;
using Notebook.Domain.Infrastructure;
using Notebook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notebook.Application.ArchiveNote
{
    public class ArchiveNoteCommandHandler : IRequestHandler<ArchiveNoteCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly INoteRepository noteRepository;

        public ArchiveNoteCommandHandler(IUnitOfWork unitOfWork, 
            INoteRepository noteRepository)
        {
            this.unitOfWork = unitOfWork;
            this.noteRepository = noteRepository;
        }

        public async Task<Unit> Handle(ArchiveNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await noteRepository.GetById(request.NoteId, cancellationToken);
            note.Archive();
            await noteRepository.Update(note, cancellationToken);
            await unitOfWork.Complete(cancellationToken);
            return Unit.Value;
        }
    }
}
