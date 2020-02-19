using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Afonsoft.Portal.Startup
{
    [DependsOn(typeof(PortalCoreModule))]
    public class PortalGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}