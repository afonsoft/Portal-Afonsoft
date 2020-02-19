using System.Threading.Tasks;
using Abp.Application.Services;
using Afonsoft.Portal.Configuration.Tenants.Dto;

namespace Afonsoft.Portal.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
