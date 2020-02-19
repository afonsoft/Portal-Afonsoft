using System.ComponentModel.DataAnnotations;

namespace Afonsoft.Portal.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}