using System.Collections.Generic;
using Afonsoft.Portal.Authorization.Users.Dto;

namespace Afonsoft.Portal.Web.Areas.App.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}