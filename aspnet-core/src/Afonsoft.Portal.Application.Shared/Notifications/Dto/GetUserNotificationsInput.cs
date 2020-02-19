using System;
using Abp.Notifications;
using Afonsoft.Portal.Dto;

namespace Afonsoft.Portal.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}