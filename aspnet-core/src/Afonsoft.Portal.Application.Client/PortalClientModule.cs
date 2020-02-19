using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Afonsoft.Portal
{
    public class PortalClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalClientModule).GetAssembly());
        }
    }
}
