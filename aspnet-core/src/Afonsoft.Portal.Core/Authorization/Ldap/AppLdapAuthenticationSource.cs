using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Afonsoft.Portal.Authorization.Users;
using Afonsoft.Portal.MultiTenancy;

namespace Afonsoft.Portal.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}