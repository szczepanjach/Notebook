using Notebook.Domain.Entities.NoteAggregate.Exceptions;
using Notebook.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Domain.Entities.NoteAggregate
{
    public class Tag: Entity
    {
        public string TagValue { get; private set; }
        public void SetTagValue(string newValue)
        {
            if(newValue.Length < 2 
                || newValue.Length > 20)
            {
                throw new IncorrectTagLenghtException();
            }
            TagValue = newValue;
        }
        public int NoteId { get; private set; }
    }
}
