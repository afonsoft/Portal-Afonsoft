using Abp.Dependency;
using GraphQL;
using GraphQL.Types;
using Afonsoft.Portal.Queries.Container;

namespace Afonsoft.Portal.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IDependencyResolver resolver) :
            base(resolver)
        {
            Query = resolver.Resolve<QueryContainer>();
        }
    }
}