using System.Collections.Generic;
using Afonsoft.Portal.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace Afonsoft.Portal.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
