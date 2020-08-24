using System.Linq;
using Abp.Configuration;
using Abp.Localization;
using Abp.MultiTenancy;
using Abp.Net.Mail;
using Microsoft.EntityFrameworkCore;
using Afonsoft.Portal.EntityFrameworkCore;

namespace Afonsoft.Portal.Migrations.Seed.Host
{
    public class DefaultSettingsCreator
    {
        private readonly PortalDbContext _context;

        public DefaultSettingsCreator(PortalDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            int? tenantId = null;

            if (!PortalConsts.MultiTenancyEnabled)
            {
                tenantId = MultiTenancyConsts.DefaultTenantId;
            }

            //Emailing
            AddSettingIfNotExists(EmailSettingNames.DefaultFromAddress, "afonso.nogueira@afonsoft.com.br", tenantId);
            AddSettingIfNotExists(EmailSettingNames.DefaultFromDisplayName, "afonsoft.com.br mailer", tenantId);

            //Languages
            AddSettingIfNotExists(LocalizationSettingNames.DefaultLanguage, "pt-BR", tenantId);
        }

        private void AddSettingIfNotExists(string name, string value, int? tenantId = null)
        {
            if (_context.Settings.IgnoreQueryFilters().Any(s => s.Name == name && s.TenantId == tenantId && s.UserId == null))
            {
                return;
            }

            _context.Settings.Add(new Setting(tenantId, null, name, value));
            _context.SaveChanges();
        }
    }
}