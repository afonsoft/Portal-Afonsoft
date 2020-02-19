using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Afonsoft.Portal.Configure;
using Afonsoft.Portal.Startup;
using Afonsoft.Portal.Test.Base;

namespace Afonsoft.Portal.GraphQL.Tests
{
    [DependsOn(
        typeof(PortalGraphQLModule),
        typeof(PortalTestBaseModule))]
    public class PortalGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalGraphQLTestModule).GetAssembly());
        }
    }
}