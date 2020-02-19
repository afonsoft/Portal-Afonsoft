using System;
using Abp.AutoMapper;
using Afonsoft.Portal.Sessions.Dto;

namespace Afonsoft.Portal.Models.Common
{
    [AutoMapFrom(typeof(ApplicationInfoDto)),
     AutoMapTo(typeof(ApplicationInfoDto))]
    public class ApplicationInfoPersistanceModel
    {
        public string Version { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}