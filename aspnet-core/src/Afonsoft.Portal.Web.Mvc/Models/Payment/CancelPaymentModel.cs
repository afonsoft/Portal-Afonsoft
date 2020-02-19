using Afonsoft.Portal.MultiTenancy.Payments;

namespace Afonsoft.Portal.Web.Models.Payment
{
    public class CancelPaymentModel
    {
        public string PaymentId { get; set; }

        public SubscriptionPaymentGatewayType Gateway { get; set; }
    }
}