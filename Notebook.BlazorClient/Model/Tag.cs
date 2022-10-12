using System.ComponentModel.DataAnnotations;

namespace Notebook.BlazorClient.Model
{
    public class Tag
    {
        public Tag(string tagValue)
        {
            TagValue = tagValue;
        }

        [MinLength(2)]
        [MaxLength(20)]
        [Required]
        public string TagValue { get; set; }
    }
}
