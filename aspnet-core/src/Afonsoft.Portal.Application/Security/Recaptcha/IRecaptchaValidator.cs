using System.Threading.Tasks;

namespace Afonsoft.Portal.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}