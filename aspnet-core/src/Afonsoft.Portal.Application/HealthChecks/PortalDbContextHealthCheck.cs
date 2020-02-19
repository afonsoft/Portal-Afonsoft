using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Afonsoft.Portal.EntityFrameworkCore;

namespace Afonsoft.Portal.HealthChecks
{
    public class PortalDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public PortalDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("PortalDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("PortalDbContext could not connect to database"));
        }
    }
}
