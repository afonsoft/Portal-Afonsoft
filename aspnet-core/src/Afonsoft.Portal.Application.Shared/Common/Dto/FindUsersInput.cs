using Afonsoft.Portal.Dto;

namespace Afonsoft.Portal.Common.Dto
{
    public class FindUsersInput : PagedAndFilteredInputDto
    {
        public int? TenantId { get; set; }
    }
}