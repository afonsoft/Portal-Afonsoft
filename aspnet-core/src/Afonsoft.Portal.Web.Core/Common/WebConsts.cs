﻿using System.Collections.Generic;

namespace Afonsoft.Portal.Web.Common
{
    public static class WebConsts
    {
        public const string SwaggerUiEndPoint = "/swagger";
        public const string HangfireDashboardEndPoint = "/hangfire";

        public static List<string> ReCaptchaIgnoreWhiteList = new List<string>
        {
            PortalConsts.AbpApiClientUserAgent
        };
    }
}
