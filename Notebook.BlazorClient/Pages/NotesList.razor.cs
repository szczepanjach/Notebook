using Microsoft.AspNetCore.Components;
using Notebook.BlazorClient.Model;
using Notebook.BlazorClient.Requests;
using Notebook.BlazorClient.Services;

namespace Notebook.BlazorClient.Pages
{
    public partial class NotesList
    {
        [Inject]
        public NotesService NotesListService { get; set; }
        bool isInitailized = false;
        private IEnumerable<NotesListItem> notes;

        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            notes = await NotesListService.GetNotesList();
            isInitailized = true;
        }

        private string GetDetailsLink(int id)
        {
            return $"notedetails/{id}";
        }

        private string GetEditLink(int id)
        {
            return $"editnote/{id}";
        }

        private async Task ArchiveNote(int id)
        {
            var archiveNoteRequest = new ArchiveNoteRequest()
            {
                NoteId = id
            };
            await NotesListService.ArchiveNote(archiveNoteRequest);
            notes = await NotesListService.GetNotesList();
        }

        private async Task DeleteNote(int noteId)
        {
            await NotesListService.DeleteNote(noteId);
            notes = await NotesListService.GetNotesList();
        }
    }
}
