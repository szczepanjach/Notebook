using System.Collections.Generic;

namespace Notebook.Api.Contract
{
    public class UpdateNoteRequest
    {
        public int NoteId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public IEnumerable<string> TagsToAdd { get; set; }
        public IEnumerable<string> TagsToDelete { get; set; }
    }
}
