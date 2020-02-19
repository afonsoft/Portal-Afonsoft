using Abp.AutoMapper;
using Afonsoft.Portal.MultiTenancy.Dto;

namespace Afonsoft.Portal.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
    }
}
