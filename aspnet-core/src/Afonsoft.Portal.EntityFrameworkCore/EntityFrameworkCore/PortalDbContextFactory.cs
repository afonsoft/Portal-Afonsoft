using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Afonsoft.Portal.Configuration;
using Afonsoft.Portal.Web;

namespace Afonsoft.Portal.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class PortalDbContextFactory : IDesignTimeDbContextFactory<PortalDbContext>
    {
        public PortalDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PortalDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), addUserSecrets: true);

            PortalDbContextConfigurer.Configure(builder, configuration.GetConnectionString(PortalConsts.ConnectionStringName));

            return new PortalDbContext(builder.Options);
        }
    }
}