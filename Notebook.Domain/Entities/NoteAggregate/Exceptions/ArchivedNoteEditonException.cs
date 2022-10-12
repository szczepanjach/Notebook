using Notebook.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Domain.Entities.NoteAggregate.Exceptions
{
    public class ArchivedNoteEditonException : DomainException
    {
        public ArchivedNoteEditonException() : base("Archvied note can not be modified.")
        {
        }
    }
}
