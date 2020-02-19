using Abp.AutoMapper;
using Afonsoft.Portal.Authorization.Users;
using Afonsoft.Portal.Authorization.Users.Dto;
using Afonsoft.Portal.Web.Areas.App.Models.Common;

namespace Afonsoft.Portal.Web.Areas.App.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; set; }
    }
}