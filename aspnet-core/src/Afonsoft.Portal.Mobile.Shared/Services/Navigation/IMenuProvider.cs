using System.Collections.Generic;
using MvvmHelpers;
using Afonsoft.Portal.Models.NavigationMenu;

namespace Afonsoft.Portal.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}