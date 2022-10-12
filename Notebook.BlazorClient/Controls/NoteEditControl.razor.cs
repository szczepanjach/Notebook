using Microsoft.AspNetCore.Components;
using Notebook.BlazorClient.Model;
using Notebook.BlazorClient.Services;

namespace Notebook.BlazorClient.Controls
{
    public partial class NoteEditControl
    {
        [Parameter]
        public Note Note { get; set; }
        [Parameter]
        public EventCallback OnNoteSaved { get; set; }
        [Inject]
        public NotesService NotesService { get; set; }

        private bool isSubjectInUse = false;
        private bool isAddingNewTag = false;
        private string newTagValue = string.Empty;

        private void AddNewTag()
        {
            isAddingNewTag = true;
        }

        private void SaveNewTag()
        {
            isAddingNewTag = false;
            Note.Tags.Add(new Tag(newTagValue));
            Note.TagsToAdd.Add(newTagValue);
            newTagValue = string.Empty;
        }

        private async Task OnSave()
        {
            isSubjectInUse = false;
            if (await NotesService.IsSubjectInUse(Note.Id, Note.Subject))
            {
                isSubjectInUse = true;
                return;
            }
            await OnNoteSaved.InvokeAsync();
        }

        private void RemoveTag(Tag tag)
        {
            Note.Tags.Remove(tag);
            Note.TagsToRemove.Add(tag.TagValue);
        }
    }
}
