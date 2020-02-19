using System.Collections.Generic;
using Afonsoft.Portal.Authorization.Users.Importing.Dto;
using Afonsoft.Portal.Dto;

namespace Afonsoft.Portal.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
