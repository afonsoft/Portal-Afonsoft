using Abp.Auditing;
using Afonsoft.Portal.Configuration.Dto;

namespace Afonsoft.Portal.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}