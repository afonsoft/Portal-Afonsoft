using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace Afonsoft.Portal.Web.TagHelpers
{
    [HtmlTargetElement("recaptcha", TagStructure = TagStructure.WithoutEndTag)]
    public class AbpZeroRecaptchaTagHelper : TagHelper
    {
        private IRecaptchaConfigurationService _service;

        internal const string RecaptchaValidationJSCallBack = "recaptchaValidated";

        private const string ThemeAttributeName = "theme";
        private const string TypeAttributeName = "type";
        private const string SizeAttributeName = "size";
        private const string TabindexAttributeName = "tabindex";

        [HtmlAttributeName(ThemeAttributeName)]
        public RecaptchaTheme? Theme { get; set; }

        [HtmlAttributeName(TypeAttributeName)]
        public RecaptchaType? Type { get; set; }

        [HtmlAttributeName(SizeAttributeName)]
        public RecaptchaSize? Size { get; set; }

        [HtmlAttributeName(TabindexAttributeName)]
        public int TabIndex { get; set; }

        public AbpZeroRecaptchaTagHelper(IRecaptchaConfigurationService service)
        {
            //service.CheckArgumentNull(nameof(service));

            _service = service;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!_service.Enabled)
            {
                output.TagName = null;
                return;
            }

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "g-recaptcha");
            output.Attributes.Add("data-sitekey", _service.SiteKey);
            output.Attributes.Add("data-callback", RecaptchaValidationJSCallBack);

            var controlSettings = _service.ControlSettings;

            if ((Theme ?? controlSettings.Theme) == RecaptchaTheme.Dark)
            {
                output.Attributes.Add("data-theme", "dark");
            }

            if ((Type ?? controlSettings.Type) == RecaptchaType.Audio)
            {
                output.Attributes.Add("data-type", "audio");
            }

            if ((Size ?? controlSettings.Size) == RecaptchaSize.Compact)
            {
                output.Attributes.Add("data-size", "compact");
            }

            if (TabIndex != 0)
            {
                output.Attributes.Add("data-tabindex", TabIndex);
            }
        }
    }
}
