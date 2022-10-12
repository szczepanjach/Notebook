using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Application.DeleteNote
{
    public class DeleteNoteCommand : IRequest
    {
        public int NoteId { get; set; }
    }
}
