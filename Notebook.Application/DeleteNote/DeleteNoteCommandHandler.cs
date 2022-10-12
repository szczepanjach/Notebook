using MediatR;
using Notebook.Domain.Infrastructure;
using Notebook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notebook.Application.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly INoteRepository noteRepository;

        public DeleteNoteCommandHandler(IUnitOfWork unitOfWork, 
            INoteRepository noteRepository)
        {
            this.unitOfWork = unitOfWork;
            this.noteRepository = noteRepository;
        }

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            await noteRepository.Delete(request.NoteId, cancellationToken);
            await unitOfWork.Complete(cancellationToken);
            return Unit.Value;
        }
    }
}
