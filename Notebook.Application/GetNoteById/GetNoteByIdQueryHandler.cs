using MediatR;
using Notebook.Domain.Entities.NoteAggregate;
using Notebook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notebook.Application.GetNoteById
{
    public class GetNoteByIdQueryHandler : IRequestHandler<GetNoteByIdQuery, Note>
    {
        private readonly INoteRepository noteRepository;

        public GetNoteByIdQueryHandler(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public async Task<Note> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            return await noteRepository.GetById(request.NoteId, cancellationToken);
        }
    }
}
