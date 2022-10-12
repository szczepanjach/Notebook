using MediatR;
using Notebook.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Notebook.Domain.Entities.NoteAggregate;
using Notebook.Domain.DomainServices;
using Notebook.Domain.Repositories;

namespace Notebook.Application.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly INoteRepository noteRepository;
        private readonly IIsSubjectUsedService isSubjectUsedService;

        public CreateNoteCommandHandler(IUnitOfWork unitOfWork, 
            IIsSubjectUsedService isSubjectUsedService, 
            INoteRepository noteRepository)
        {
            this.unitOfWork = unitOfWork;
            this.isSubjectUsedService = isSubjectUsedService;
            this.noteRepository = noteRepository;
        }
        public async Task<int> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            if (isSubjectUsedService.IsSubjectAlreadyUsed(request.Subject, 0))
            {
                return default;
            }
            var note = new Note();
            note.SetSubject(request.Subject, isSubjectUsedService);
            note.SetBody(request.Body);
            foreach (var tagToAdd in request.Tags)
            {
                note.AddTag(tagToAdd);
            }
            await noteRepository.Create(note, cancellationToken);
            await unitOfWork.Complete(cancellationToken);
            return note.Id;
        }
    }
}
