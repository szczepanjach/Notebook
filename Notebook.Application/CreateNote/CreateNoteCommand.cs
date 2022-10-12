using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Application.CreateNote
{
    public class CreateNoteCommand : IRequest<int>
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public IEnumerable<string> Tags { get; set; } = new List<string>();
    }
}
