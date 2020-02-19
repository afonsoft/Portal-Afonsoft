using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Afonsoft.Portal.Configuration.Tenants.Dto;

namespace Afonsoft.Portal.Web.Areas.App.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}