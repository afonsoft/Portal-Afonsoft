using System.Threading.Tasks;
using Abp.Application.Services;
using Afonsoft.Portal.Install.Dto;

namespace Afonsoft.Portal.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}