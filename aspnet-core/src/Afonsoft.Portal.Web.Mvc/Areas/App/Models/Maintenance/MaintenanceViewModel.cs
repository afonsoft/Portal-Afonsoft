using System.Collections.Generic;
using Afonsoft.Portal.Caching.Dto;

namespace Afonsoft.Portal.Web.Areas.App.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}