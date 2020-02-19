using System.Collections.Generic;
using Afonsoft.Portal.DashboardCustomization.Dto;

namespace Afonsoft.Portal.Web.Areas.App.Models.CustomizableDashboard
{
    public class AddWidgetViewModel
    {
        public List<WidgetOutput> Widgets { get; set; }

        public string DashboardName { get; set; }

        public string PageId { get; set; }
    }
}
