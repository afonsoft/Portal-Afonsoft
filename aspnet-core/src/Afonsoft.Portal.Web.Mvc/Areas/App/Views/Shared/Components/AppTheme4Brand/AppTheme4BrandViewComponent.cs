using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Afonsoft.Portal.Web.Areas.App.Models.Layout;
using Afonsoft.Portal.Web.Session;
using Afonsoft.Portal.Web.Views;

namespace Afonsoft.Portal.Web.Areas.App.Views.Shared.Components.AppTheme4Brand
{
    public class AppTheme4BrandViewComponent : PortalViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme4BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
