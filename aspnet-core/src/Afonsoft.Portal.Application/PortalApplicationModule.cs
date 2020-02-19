using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Afonsoft.Portal.Authorization;

namespace Afonsoft.Portal
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(PortalApplicationSharedModule),
        typeof(PortalCoreModule)
        )]
    public class PortalApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalApplicationModule).GetAssembly());
        }
    }
}