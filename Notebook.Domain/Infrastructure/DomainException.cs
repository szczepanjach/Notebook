using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Domain.Infrastructure
{
    public class DomainException:Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
