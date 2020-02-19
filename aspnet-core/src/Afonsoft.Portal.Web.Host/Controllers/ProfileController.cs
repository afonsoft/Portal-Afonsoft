using Abp.AspNetCore.Mvc.Authorization;
using Afonsoft.Portal.Storage;

namespace Afonsoft.Portal.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(ITempFileCacheManager tempFileCacheManager) :
            base(tempFileCacheManager)
        {
        }
    }
}