using MediatR;
using Notebook.Application.GetNotesList;
using Notebook.Domain.Entities.NoteAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Application.GetNoteById
{
    public class GetNoteByIdQuery: IRequest<Note>
    {
        public GetNoteByIdQuery(int noteId)
        {
            NoteId = noteId;
        }

        public int NoteId { get; set; }
    }
}
