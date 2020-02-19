using System.Collections.Generic;
using Afonsoft.Portal.Editions.Dto;
using Afonsoft.Portal.MultiTenancy.Payments;

namespace Afonsoft.Portal.Web.Models.Payment
{
    public class ExtendEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}