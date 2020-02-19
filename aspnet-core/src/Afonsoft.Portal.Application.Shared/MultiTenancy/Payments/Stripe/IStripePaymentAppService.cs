using System.Threading.Tasks;
using Abp.Application.Services;
using Afonsoft.Portal.MultiTenancy.Payments.Dto;
using Afonsoft.Portal.MultiTenancy.Payments.Stripe.Dto;

namespace Afonsoft.Portal.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}