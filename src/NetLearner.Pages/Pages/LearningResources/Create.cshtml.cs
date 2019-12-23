using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;
using NetLearner.SharedLib.Services;

namespace NetLearner.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ILearningResourceService _learningResourceService;

        public CreateModel(ILearningResourceService learningResourceService)
        {
            _learningResourceService = learningResourceService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LearningResource LearningResource { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _learningResourceService.Add(LearningResource);

            return RedirectToPage("./Index");
        }
    }
}
