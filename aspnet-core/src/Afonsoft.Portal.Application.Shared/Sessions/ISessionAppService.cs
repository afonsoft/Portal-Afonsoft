using System.Threading.Tasks;
using Abp.Application.Services;
using Afonsoft.Portal.Sessions.Dto;

namespace Afonsoft.Portal.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
