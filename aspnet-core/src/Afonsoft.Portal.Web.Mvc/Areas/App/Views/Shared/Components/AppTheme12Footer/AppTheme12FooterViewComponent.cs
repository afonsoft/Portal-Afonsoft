﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Afonsoft.Portal.Web.Areas.App.Models.Layout;
using Afonsoft.Portal.Web.Session;
using Afonsoft.Portal.Web.Views;

namespace Afonsoft.Portal.Web.Areas.App.Views.Shared.Components.AppTheme12Footer
{
    public class AppTheme12FooterViewComponent : PortalViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme12FooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
