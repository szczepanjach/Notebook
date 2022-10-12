using Notebook.BlazorClient.Model;
using System.ComponentModel.DataAnnotations;

namespace Notebook.BlazorClient.Validators
{
    public class UniqueTagsValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (!(value is IEnumerable<Tag> tags))
            {
                return false;
            }
            var tagsString = tags.Select(s => s.TagValue);
            var uniqueTags = tagsString.Distinct();
            if(tags.Count() != uniqueTags.Count())
            {
                ErrorMessage = "tagi nie mogą się powtarzać";
                return false;
            }
            return true;
        }
    }
}
