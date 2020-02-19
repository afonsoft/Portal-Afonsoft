using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Afonsoft.Portal.Dto;

namespace Afonsoft.Portal.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
