using System.Threading.Tasks;
using Abp.Authorization.Users;
using Afonsoft.Portal.Authorization.Users;

namespace Afonsoft.Portal.Authorization
{
    public static class UserManagerExtensions
    {
        public static async Task<User> GetAdminAsync(this UserManager userManager)
        {
            return await userManager.FindByNameAsync(AbpUserBase.AdminUserName);
        }
    }
}
