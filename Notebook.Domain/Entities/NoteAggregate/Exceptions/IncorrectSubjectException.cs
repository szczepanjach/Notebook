using Notebook.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Domain.Entities.NoteAggregate.Exceptions
{
    public class IncorrectSubjectException : DomainException
    {
        public IncorrectSubjectException() : base("Incorrect subject")
        {
        }
    }
}
