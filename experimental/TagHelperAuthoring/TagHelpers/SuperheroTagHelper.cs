using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagHelperAuthoring.Models;

namespace TagHelperAuthoring.TagHelpers
{
    public class SuperheroTagHelper : TagHelper
    {
        public SuperheroModel HeroInfo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string htmlContent = $@"<ul><li><strong>First Name:</strong> {HeroInfo.FirstName}</li>
<li><strong>Last Name:</strong> {HeroInfo.LastName}</li>
<li><strong>Superhero Name:</strong> {HeroInfo.SuperName}</li>
<li><strong>Survived Endgame? </strong> {HeroInfo.HasSurvived}</li></ul>";
            output.TagName = "section";
            output.Content.SetHtmlContent(htmlContent);
            output.TagMode = TagMode.StartTagAndEndTag;
        }

    }
}
