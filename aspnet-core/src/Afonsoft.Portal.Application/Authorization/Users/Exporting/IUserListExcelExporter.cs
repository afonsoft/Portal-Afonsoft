using System.Collections.Generic;
using Afonsoft.Portal.Authorization.Users.Dto;
using Afonsoft.Portal.Dto;

namespace Afonsoft.Portal.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}