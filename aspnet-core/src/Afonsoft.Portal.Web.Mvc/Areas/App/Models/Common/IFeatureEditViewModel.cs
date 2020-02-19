using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Afonsoft.Portal.Editions.Dto;

namespace Afonsoft.Portal.Web.Areas.App.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}