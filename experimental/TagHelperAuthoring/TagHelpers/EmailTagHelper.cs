using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelperAuthoring.TagHelpers
{
    public class EmailTagHelper: TagHelper
    {
        private const string EmailDomain = "avengers.mcu";

        // Can be passed via <email mail-to="..." />. 
        // PascalCase gets translated into kebab-case.
        public string MailTo { get; set; }

        // synchronous method, CANNOT call output.GetChildContentAsync();
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // 1. Set the HTML element as the tag name to replace it with, e.g. <a>
            output.TagName = "a";

            var address = MailTo + "@" + EmailDomain;

            // 2. Set the href attribute within that HTML element, e.g. href
            output.Attributes.SetAttribute("href", "mailto:" + address);

            // 3. Set HTML Content within the tags.
            output.Content.SetContent(address);
        }

    }
}
