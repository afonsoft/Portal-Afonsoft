using Afonsoft.Portal.EntityFrameworkCore;

namespace Afonsoft.Portal.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly PortalDbContext _context;

        public InitialHostDbBuilder(PortalDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
