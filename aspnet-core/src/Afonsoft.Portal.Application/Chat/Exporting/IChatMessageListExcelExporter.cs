using System.Collections.Generic;
using Afonsoft.Portal.Chat.Dto;
using Afonsoft.Portal.Dto;

namespace Afonsoft.Portal.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(List<ChatMessageExportDto> messages);
    }
}
