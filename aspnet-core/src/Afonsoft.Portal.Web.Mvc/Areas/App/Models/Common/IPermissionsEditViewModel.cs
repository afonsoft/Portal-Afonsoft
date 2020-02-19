using System.Collections.Generic;
using Afonsoft.Portal.Authorization.Permissions.Dto;

namespace Afonsoft.Portal.Web.Areas.App.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}