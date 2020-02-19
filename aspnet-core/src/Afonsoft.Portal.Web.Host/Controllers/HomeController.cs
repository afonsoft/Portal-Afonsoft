using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;

namespace Afonsoft.Portal.Web.Controllers
{
    public class HomeController : PortalControllerBase
    {
        [DisableAuditing]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Ui");
        }
    }
}
