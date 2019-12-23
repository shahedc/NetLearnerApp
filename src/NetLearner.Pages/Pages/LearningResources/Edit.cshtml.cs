using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;
using NetLearner.SharedLib.Services;

namespace NetLearner.Pages
{
    public class EditModel : PageModel
    {
        private readonly ILearningResourceService _learningResourceService;

        public EditModel(ILearningResourceService learningResourceService)
        {
            _learningResourceService = learningResourceService;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _learningResourceService.Update(LearningResource);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearningResourceExists(LearningResource.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LearningResourceExists(int id)
        {
            var learningResource = _learningResourceService.Get(id);
            return (learningResource != null);

        }
    }
}
