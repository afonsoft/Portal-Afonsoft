using Abp.AspNetCore.Mvc.Authorization;
using Afonsoft.Portal.Authorization;
using Afonsoft.Portal.Storage;
using Abp.BackgroundJobs;

namespace Afonsoft.Portal.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}