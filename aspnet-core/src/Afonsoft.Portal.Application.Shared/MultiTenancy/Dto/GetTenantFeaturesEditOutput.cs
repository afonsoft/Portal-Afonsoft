using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Afonsoft.Portal.Editions.Dto;

namespace Afonsoft.Portal.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}