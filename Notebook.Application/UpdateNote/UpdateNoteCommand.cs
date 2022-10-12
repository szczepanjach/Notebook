using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Application.UpdateNote
{
    public class UpdateNoteCommand : IRequest
    {
        public int NoteId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public IEnumerable<string> TagsToAdd { get; set; }
        public IEnumerable<string> TagsToDelete { get; set; }
    }
}
