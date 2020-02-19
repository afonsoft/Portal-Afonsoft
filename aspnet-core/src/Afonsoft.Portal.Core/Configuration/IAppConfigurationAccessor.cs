using Microsoft.Extensions.Configuration;

namespace Afonsoft.Portal.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
