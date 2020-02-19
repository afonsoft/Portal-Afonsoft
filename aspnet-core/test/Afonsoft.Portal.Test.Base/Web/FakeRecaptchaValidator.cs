using System.Threading.Tasks;
using Afonsoft.Portal.Security.Recaptcha;

namespace Afonsoft.Portal.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
