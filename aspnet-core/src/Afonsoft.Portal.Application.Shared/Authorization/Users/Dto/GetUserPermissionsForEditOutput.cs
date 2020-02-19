using System.Collections.Generic;
using Afonsoft.Portal.Authorization.Permissions.Dto;

namespace Afonsoft.Portal.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}