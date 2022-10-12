using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Application.ArchiveNote
{
    public class ArchiveNoteCommand: IRequest
    {
        public int NoteId { get; set; }
    }
}
