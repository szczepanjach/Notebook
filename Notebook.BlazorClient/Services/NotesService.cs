using Newtonsoft.Json;
using Notebook.BlazorClient.Model;
using Notebook.BlazorClient.Requests;
using System.Net.Http.Json;

namespace Notebook.BlazorClient.Services
{
    public class NotesService
    {
        private readonly string noteApiAddress = "https://localhost:44352/note";
        private readonly HttpClient httpClient;
        public NotesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<NotesListItem>> GetNotesList()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<NotesListItem>>(noteApiAddress + "/getall");
        }

        public async Task<Note> GetNote(int id)
        {
            return await httpClient.GetFromJsonAsync<Note>(noteApiAddress + $"/getbyid/{id}");
        }

        public async Task CreateNote(CreateNoteRequest createNoteRequest)
        {
            await httpClient.PostAsJsonAsync(noteApiAddress + "/create", createNoteRequest);
        }

        public async Task UpdateNote(UpdateNoteRequest updateNoteRequest)
        {
            await httpClient.PostAsJsonAsync(noteApiAddress + "/update", updateNoteRequest);
        }

        public async Task<bool> IsSubjectInUse(int noteId, string subject)
        {
            return await httpClient.GetFromJsonAsync<bool>($"{noteApiAddress}/issubjectinuse/{noteId}/{subject}");
        }

        public async Task ArchiveNote(ArchiveNoteRequest archiveNoteRequest)
        {
            await httpClient.PostAsJsonAsync(noteApiAddress + "/archivenote", archiveNoteRequest);
        }

        public async Task DeleteNote(int noteId)
        {
            await httpClient.DeleteAsync(noteApiAddress + "/deletenote/" + noteId);
        }
    }
}
