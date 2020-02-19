using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Afonsoft.Portal.Configuration.Host.Dto;
using Afonsoft.Portal.Editions.Dto;

namespace Afonsoft.Portal.Web.Areas.App.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}