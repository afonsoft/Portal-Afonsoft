using Abp.AutoMapper;
using Afonsoft.Portal.Sessions.Dto;

namespace Afonsoft.Portal.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}