using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Afonsoft.Portal
{
    public class PortalCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalCoreSharedModule).GetAssembly());
        }
    }
}