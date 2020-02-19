using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Afonsoft.Portal
{
    [DependsOn(typeof(PortalClientModule), typeof(AbpAutoMapperModule))]
    public class PortalXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalXamarinSharedModule).GetAssembly());
        }
    }
}