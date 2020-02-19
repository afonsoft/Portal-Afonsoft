using System.Collections.Generic;
using Afonsoft.Portal.Auditing.Dto;
using Afonsoft.Portal.Dto;

namespace Afonsoft.Portal.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
