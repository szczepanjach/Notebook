using Notebook.BlazorClient.Validators;
using System.ComponentModel.DataAnnotations;

namespace Notebook.BlazorClient.Model
{
    public class Note
    {
        public Note()
        {
            Tags = new List<Tag>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage ="Teamt jest wymagany")]
        [MinLength(4, ErrorMessage ="Temat musi mieć przynajmniej 4 znaki")]
        [MaxLength(50, ErrorMessage = "Temat nie moze mieć więcej niż 50 znaków")]
        public string Subject { get; set; }
        public bool IsArchived { get; set; }
        public DateTime  LastUpdateDate { get; set; }
        [Required(ErrorMessage = "Treść jest wymagana")]
        [MaxLength(2000, ErrorMessage ="Treść nie może być dłuższa niż 2000 znaków")]
        public string Body { get; set; }
        [TagsAmountValidator]
        [UniqueTagsValidator]
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<string> TagsToRemove { get; set; } = new List<string>();
        public List<string> TagsToAdd { get; set; } = new List<string>();
    }
}