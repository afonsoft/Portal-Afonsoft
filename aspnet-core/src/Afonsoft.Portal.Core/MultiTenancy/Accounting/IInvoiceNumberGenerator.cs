using System.Threading.Tasks;
using Abp.Dependency;

namespace Afonsoft.Portal.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}