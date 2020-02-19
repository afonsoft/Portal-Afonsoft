using System.Threading.Tasks;
using Abp.Application.Services;
using Afonsoft.Portal.Editions.Dto;
using Afonsoft.Portal.MultiTenancy.Dto;

namespace Afonsoft.Portal.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}