using Abp.Authorization;
using Afonsoft.Portal.Authorization.Roles;
using Afonsoft.Portal.Authorization.Users;

namespace Afonsoft.Portal.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
