using Notebook.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Domain.Entities.NoteAggregate.Exceptions
{
    public class TagsDuplicatedException : DomainException
    {
        public TagsDuplicatedException() : base("Tags within one note can not be duplicated.")
        {
        }
    }
}
