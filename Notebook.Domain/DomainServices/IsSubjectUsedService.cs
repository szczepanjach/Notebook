using Notebook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notebook.Domain.DomainServices
{
    public class IsSubjectUsedService: IIsSubjectUsedService
    {
        private readonly INoteRepository noteRepository;

        public IsSubjectUsedService(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public virtual bool IsSubjectAlreadyUsed(string subiect, int noteId)
        {
            return noteRepository.ExistsWithSubject(subiect, noteId);
        }
    }
}
