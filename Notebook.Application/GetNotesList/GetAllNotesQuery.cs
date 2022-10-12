using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Application.GetNotesList
{
    public class GetAllNotesQuery : IRequest<IEnumerable<NoteDto>>
    {
    }
}
