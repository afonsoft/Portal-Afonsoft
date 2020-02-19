using System.Collections.Generic;
using Afonsoft.Portal.Editions;
using Afonsoft.Portal.Editions.Dto;
using Afonsoft.Portal.MultiTenancy.Payments;
using Afonsoft.Portal.MultiTenancy.Payments.Dto;

namespace Afonsoft.Portal.Web.Models.Payment
{
    public class BuyEditionViewModel
    {
        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}
