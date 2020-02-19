using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Afonsoft.Portal.MultiTenancy.Accounting.Dto;

namespace Afonsoft.Portal.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
