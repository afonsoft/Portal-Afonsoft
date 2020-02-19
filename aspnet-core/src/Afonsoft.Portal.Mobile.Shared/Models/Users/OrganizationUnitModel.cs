using Abp.AutoMapper;
using Afonsoft.Portal.Organizations.Dto;

namespace Afonsoft.Portal.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}