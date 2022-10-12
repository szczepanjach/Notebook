using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Application.GetNotesList
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool IsArchived { get; set; }
    }
}
