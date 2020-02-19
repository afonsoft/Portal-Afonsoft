using Afonsoft.Portal.Editions;
using Afonsoft.Portal.Editions.Dto;
using Afonsoft.Portal.MultiTenancy.Payments;
using Afonsoft.Portal.Security;
using Afonsoft.Portal.MultiTenancy.Payments.Dto;

namespace Afonsoft.Portal.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
    }
}
