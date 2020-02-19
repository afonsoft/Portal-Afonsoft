using System.ComponentModel.DataAnnotations;

namespace Afonsoft.Portal.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}