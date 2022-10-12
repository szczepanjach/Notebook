using Notebook.BlazorClient.Model;
using System.ComponentModel.DataAnnotations;

namespace Notebook.BlazorClient.Validators
{
    public class TagsAmountValidator: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(!(value is IEnumerable<Tag> tags))
            {
                return false;
            }
            if(tags.Count() > 10)
            {
                ErrorMessage = "Notatka może zawierać maksymalnie 10 tagów.";
                return false;
            }
            return true;
        }
    }
}
