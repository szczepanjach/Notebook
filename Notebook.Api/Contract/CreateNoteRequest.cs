using System.Collections.Generic;

namespace Notebook.Api.Contract
{
    public class CreateNoteRequest
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
