using Notebook.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Domain.Entities.NoteAggregate.Exceptions
{
    public class IncorrectBodyException : DomainException
    {
        public IncorrectBodyException() : base("Incorrect body")
        {
        }
    }
}
