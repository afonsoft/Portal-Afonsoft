using System.ComponentModel.DataAnnotations;

namespace Afonsoft.Portal.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
