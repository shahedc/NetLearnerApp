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

namespace NetLearner.Pages.LearningResources
{
    public class CreateModel : PageModel
    {
        private readonly ILearningResourceService _learningResourceService;
        private readonly IResourceListService _resourceListService;

        public CreateModel(ILearningResourceService learningResourceService, IResourceListService resourceListService)
        {
            _learningResourceService = learningResourceService;
            _resourceListService = resourceListService;
        }

        public async Task<IActionResult> OnGet()
        {
            var resourceList = await _resourceListService.Get();
            ViewData["ResourceListId"] = new SelectList(resourceList, "Id", "Name");
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

            var resourceList = await _resourceListService.Get();
            ViewData["ResourceListId"] = new SelectList(resourceList, "Id", "Name", LearningResource.ResourceListId);
            return RedirectToPage("./Index");
        }
    }
}
