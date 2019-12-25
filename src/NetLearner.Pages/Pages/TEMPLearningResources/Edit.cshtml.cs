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

namespace NetLearner.Pages.TEMPLearningResources
{
    public class EditModel : PageModel
    {
        private readonly NetLearner.SharedLib.Data.LibDbContext _context;

        public EditModel(NetLearner.SharedLib.Data.LibDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LearningResource LearningResource { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LearningResource = await _context.LearningResources
                .Include(l => l.ResourceList).FirstOrDefaultAsync(m => m.Id == id);

            if (LearningResource == null)
            {
                return NotFound();
            }
           ViewData["ResourceListId"] = new SelectList(_context.ResourceLists, "Id", "Id");
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

            _context.Attach(LearningResource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            return _context.LearningResources.Any(e => e.Id == id);
        }
    }
}
