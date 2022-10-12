using Notebook.Domain.DomainServices;
using Notebook.Domain.Entities.NoteAggregate.Exceptions;
using Notebook.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook.Domain.Entities.NoteAggregate
{
    public class Note: AggregateRoot
    {
        public string Subject { get; private set; }
        public void SetSubject(string subject, IIsSubjectUsedService isSubjectUsedService)
        {
            if (IsArchived)
            {
                throw new ArchivedNoteEditonException();
            }
            if (isSubjectUsedService.IsSubjectAlreadyUsed(subject, Id))
            {
                throw new SubjectDuplicatedException();
            }

            if(string.IsNullOrWhiteSpace(subject)
                || subject.Length < 4
                || subject.Length > 50)
            {
                throw new IncorrectSubjectException();
            }
            Subject = subject;
            LastUpdateDate = DateTime.Now;
        }

        public string Body { get; private set; }
        public void SetBody(string body)
        {
            if (IsArchived)
            {
                throw new ArchivedNoteEditonException();
            }
            if (string.IsNullOrWhiteSpace(body)
                || body.Length > 2000)
            {
                throw new IncorrectBodyException();
            }
            Body = body;
            LastUpdateDate = DateTime.Now;
        }

        private readonly List<Tag> tags = new List<Tag>();
        public IReadOnlyCollection<Tag> Tags => tags.AsReadOnly();
        public void AddTag(string tagValue)
        {
            if (IsArchived)
            {
                throw new ArchivedNoteEditonException();
            }
            if (tags.Count >= 10)
            {
                throw new UnableToAddMoreThan10TagsException();
            }
            if (tags.Any(tag => tag.TagValue.Equals(tagValue, StringComparison.OrdinalIgnoreCase)))
            {
                throw new TagsDuplicatedException();
            }
            var tag = new Tag();
            tag.SetTagValue(tagValue);
            tags.Add(tag);
            LastUpdateDate = DateTime.Now;
        }

        public void RemoveTag(string tagValue)
        {
            if (IsArchived)
            {
                throw new ArchivedNoteEditonException();
            }
            var toRemove = tags.FirstOrDefault(t => t.TagValue.Equals(tagValue, StringComparison.OrdinalIgnoreCase));
            if(toRemove == null)
            {
                return;
            }
            tags.Remove(toRemove);
            LastUpdateDate = DateTime.Now;
        }


        public bool IsArchived { get; private set; }
        public void Archive()
        {
            IsArchived = true;
            LastUpdateDate = DateTime.Now;
        }

        public DateTime LastUpdateDate { get; private set; }
    }
}
