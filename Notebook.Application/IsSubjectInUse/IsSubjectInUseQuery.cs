using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Application.IsSubjectInUse
{
    public class IsSubjectInUseQuery: IRequest<bool>
    {
        public IsSubjectInUseQuery(string subject, 
            int noteId)
        {
            Subject = subject;
            NoteId = noteId;
        }
        public string Subject { get; set; }
        public int NoteId { get; set; }
    }
}
