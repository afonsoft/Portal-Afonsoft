using System.Threading.Tasks;
using Abp.Application.Services;
using Afonsoft.Portal.Configuration.Host.Dto;

namespace Afonsoft.Portal.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
