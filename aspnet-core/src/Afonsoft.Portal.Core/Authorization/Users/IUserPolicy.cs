using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace Afonsoft.Portal.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
