namespace Notebook.BlazorClient.Model
{
    public class NotesListItem
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool IsArchived { get; set; }
    }
}
