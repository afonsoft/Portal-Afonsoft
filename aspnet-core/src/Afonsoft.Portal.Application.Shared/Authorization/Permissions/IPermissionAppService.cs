using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Afonsoft.Portal.Authorization.Permissions.Dto;

namespace Afonsoft.Portal.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
