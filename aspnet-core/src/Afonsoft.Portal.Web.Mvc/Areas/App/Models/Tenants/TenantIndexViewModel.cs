using System.Collections.Generic;
using Afonsoft.Portal.Editions.Dto;

namespace Afonsoft.Portal.Web.Areas.App.Models.Tenants
{
    public class TenantIndexViewModel
    {
        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }
    }
}