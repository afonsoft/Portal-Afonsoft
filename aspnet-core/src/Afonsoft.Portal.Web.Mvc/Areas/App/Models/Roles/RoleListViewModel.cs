﻿using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Afonsoft.Portal.Authorization.Permissions.Dto;
using Afonsoft.Portal.Web.Areas.App.Models.Common;

namespace Afonsoft.Portal.Web.Areas.App.Models.Roles
{
    public class RoleListViewModel : IPermissionsEditViewModel
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}