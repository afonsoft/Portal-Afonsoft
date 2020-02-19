using System.Collections.Generic;
using Abp.Localization;
using Afonsoft.Portal.Install.Dto;

namespace Afonsoft.Portal.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
