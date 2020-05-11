using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelperAuthoring.TagHelpers
{
    public class AsyncEmailTagHelper : TagHelper
    {
        private const string EmailDomain = "avengers.mcu";

        // Can be passed via <email mail-to="..." />. 
        // PascalCase gets translated into kebab-case.
        public string MailTo { get; set; }

        // ASYNC method, REQUIRED to call output.GetChildContentAsync();
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // 1. Set the HTML element as the tag name to replace it with, e.g. <a>
            output.TagName = "a";

            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + "@" + EmailDomain;

            // 2. Set the href attribute within that HTML element, e.g. href
            output.Attributes.SetAttribute("href", "mailto:" + target);

            // 3. Set HTML Content within the tags.
            output.Content.SetContent(target);
        }
    }
}
