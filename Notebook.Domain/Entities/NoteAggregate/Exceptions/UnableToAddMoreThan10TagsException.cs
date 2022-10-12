using Notebook.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Domain.Entities.NoteAggregate.Exceptions
{
    public class UnableToAddMoreThan10TagsException : DomainException
    {
        public UnableToAddMoreThan10TagsException() : base("Unable to add more than 10 tags per one note.")
        {
        }
    }
}
