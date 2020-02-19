using Abp.AutoMapper;
using Afonsoft.Portal.Editions;
using Afonsoft.Portal.MultiTenancy.Payments.Dto;

namespace Afonsoft.Portal.Web.Areas.App.Models.SubscriptionManagement
{
    [AutoMapTo(typeof(ExecutePaymentDto))]
    public class PaymentResultViewModel : SubscriptionPaymentDto
    {
        public new EditionPaymentType EditionPaymentType { get; set; }
    }
}