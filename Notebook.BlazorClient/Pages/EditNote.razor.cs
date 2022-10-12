using Microsoft.AspNetCore.Components;
using Notebook.BlazorClient.Model;
using Notebook.BlazorClient.Requests;
using Notebook.BlazorClient.Services;

namespace Notebook.BlazorClient.Pages
{
    public partial class EditNote
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public NotesService NotesListService { get; set; }
        [Parameter]
        public int NoteId { get; set; }
        private bool isInitailized = false;
        private Note note;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            if (NoteId <= 0)
            {
                isInitailized = true;
                return;
            }
            note = await NotesListService.GetNote(NoteId);
            isInitailized = true;
        }
        private async Task Save()
        {
            var updateNoteRequest = new UpdateNoteRequest()
            {
                Body = note.Body,
                NoteId = note.Id,
                Subject = note.Subject,
                TagsToAdd = note.TagsToAdd,
                TagsToDelete = note.TagsToRemove
            };
            await NotesListService.UpdateNote(updateNoteRequest);
            NavigationManager.NavigateTo("noteslist");
        }
    }
}
