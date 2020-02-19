using System.ComponentModel.DataAnnotations;

namespace Afonsoft.Portal.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}