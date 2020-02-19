using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Afonsoft.Portal.EntityFrameworkCore
{
    public static class PortalDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PortalDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PortalDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}