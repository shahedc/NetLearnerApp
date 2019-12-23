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

namespace NetLearner.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILearningResourceService _learningResourceService;

        public IndexModel(ILearningResourceService learningResourceService)
        {
            _learningResourceService = learningResourceService;
        }

        public IList<LearningResource> LearningResource { get;set; }

        public async Task OnGetAsync()
        {
            LearningResource = await _learningResourceService.Get();
        }
    }
}
