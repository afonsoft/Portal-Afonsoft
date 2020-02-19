using Abp.Application.Services;
using Afonsoft.Portal.Dto;
using Afonsoft.Portal.Logging.Dto;

namespace Afonsoft.Portal.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
