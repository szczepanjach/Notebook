using Notebook.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Domain.Entities.NoteAggregate.Exceptions
{
    public class SubjectDuplicatedException : DomainException
    {
        public SubjectDuplicatedException() : base("Subject can not be duplicated")
        {
        }
    }
}
