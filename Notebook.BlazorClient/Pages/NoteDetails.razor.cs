using Microsoft.AspNetCore.Components;
using Notebook.BlazorClient.Model;
using Notebook.BlazorClient.Services;

namespace Notebook.BlazorClient.Pages
{
    public partial class NoteDetails
    {
        [Inject]
        public NotesService NotesListService { get; set; }
        [Parameter]
        public int NoteId { get; set; }
        bool isInitailized = false;
        private Note note;

        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            if(NoteId <= 0)
            {
                isInitailized = true;
                return;
            }
            note = await NotesListService.GetNote(NoteId);
            isInitailized = true;
        }
    }
}
