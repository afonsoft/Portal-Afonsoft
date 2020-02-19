using System.Threading.Tasks;
using Afonsoft.Portal.Sessions.Dto;

namespace Afonsoft.Portal.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
