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
    public class DetailsModel : PageModel
    {
        private readonly ILearningResourceService _learningResourceService;

        public DetailsModel(ILearningResourceService learningResourceService)
        {
            _learningResourceService = learningResourceService;
        }

        public LearningResource LearningResource { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            LearningResource = await _learningResourceService.Get(id);

            if (LearningResource == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
