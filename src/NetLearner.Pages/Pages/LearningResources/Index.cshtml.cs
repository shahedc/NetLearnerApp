using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;
using NetLearner.SharedLib.Services;

namespace NetLearner.Pages.LearningResources
{
    public class IndexModel : PageModel
    {
        private readonly ILearningResourceService _learningResourceService;

        public IndexModel(ILearningResourceService learningResourceService)
        {
            _learningResourceService = learningResourceService;
        }

        public IList<LearningResource> LearningResource { get;set; }
        
        [BindProperty(SupportsGet = true)]
        public int? ResourceListId { get; set; }

        // /LearningResources
        // /LearningResources?ResourceListId=n
        // /LearningResources/n
        public async Task OnGetAsync()
        {
            if (ResourceListId != null)
            {
                LearningResource = await _learningResourceService.GetForList(Convert.ToInt32(ResourceListId));
            }
            else
            {
                LearningResource = await _learningResourceService.Get();
            }
        }

    }
}
