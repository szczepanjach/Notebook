using Notebook.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Domain.Entities.NoteAggregate.Exceptions
{
    public class IncorrectTagLenghtException: DomainException
    {
        public IncorrectTagLenghtException()
            : base("Tag must have between 2 and 20 characters")
        {

        }
    }
}
