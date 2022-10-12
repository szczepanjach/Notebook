using Microsoft.AspNetCore.Components;
using Notebook.BlazorClient.Model;
using Notebook.BlazorClient.Requests;
using Notebook.BlazorClient.Services;

namespace Notebook.BlazorClient.Pages
{
    public partial class CreateNote
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public NotesService NotesListService { get; set; }
        private Note note = new Note();
        private async Task Save()
        {
            var createNoteRequest = new CreateNoteRequest()
            {
                Subject = note.Subject,
                Body = note.Body,
                Tags = note.TagsToAdd
            };
            await NotesListService.CreateNote(createNoteRequest);
            NavigationManager.NavigateTo("noteslist");
        }
    }
}
