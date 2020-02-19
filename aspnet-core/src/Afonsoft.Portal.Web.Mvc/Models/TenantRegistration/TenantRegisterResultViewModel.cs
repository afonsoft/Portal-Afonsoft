using Abp.AutoMapper;
using Afonsoft.Portal.MultiTenancy.Dto;

namespace Afonsoft.Portal.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}