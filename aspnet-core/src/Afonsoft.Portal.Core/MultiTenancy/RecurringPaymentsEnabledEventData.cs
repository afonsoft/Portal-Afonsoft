using Abp.Events.Bus;

namespace Afonsoft.Portal.MultiTenancy
{
    public class RecurringPaymentsEnabledEventData : EventData
    {
        public int TenantId { get; set; }
    }
}