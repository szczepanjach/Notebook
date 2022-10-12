using MediatR;
using Notebook.Domain.DomainServices;
using Notebook.Domain.Entities.NoteAggregate;
using Notebook.Domain.Infrastructure;
using Notebook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notebook.Application.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IIsSubjectUsedService isSubjectUsedService;
        private readonly INoteRepository noteRepository;

        public UpdateNoteCommandHandler(IUnitOfWork unitOfWork, 
            IIsSubjectUsedService isSubjectUsedService, 
            INoteRepository noteRepository)
        {
            this.unitOfWork = unitOfWork;
            this.isSubjectUsedService = isSubjectUsedService;
            this.noteRepository = noteRepository;
        }

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            if (isSubjectUsedService.IsSubjectAlreadyUsed(request.Subject, request.NoteId))
            {
                return default;
            }
            var note = await noteRepository.GetById(request.NoteId, cancellationToken);
            note.SetSubject(request.Subject, isSubjectUsedService);
            note.SetBody(request.Body);
            foreach (var tagToAdd in request.TagsToAdd)
            {
                note.AddTag(tagToAdd);
            }
            foreach (var tagToDelete in request.TagsToDelete)
            {
                note.RemoveTag(tagToDelete);
            }
            await noteRepository.Update(note, cancellationToken);
            await unitOfWork.Complete(cancellationToken);
            return Unit.Value;
        }
    }
}
