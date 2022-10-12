using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Domain.DomainServices
{
    public interface IIsSubjectUsedService
    {
        bool IsSubjectAlreadyUsed(string subiect, int noteId);
    }
}
