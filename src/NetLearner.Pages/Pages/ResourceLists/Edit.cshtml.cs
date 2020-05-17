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

namespace NetLearner.Pages.ResourceLists
{
    public class EditModel : PageModel
    {
        private readonly NetLearner.SharedLib.Data.LibDbContext _context;

        public EditModel(NetLearner.SharedLib.Data.LibDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ResourceList ResourceList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ResourceList = await _context.ResourceLists.FirstOrDefaultAsync(m => m.Id == id);

            if (ResourceList == null)
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

            _context.Attach(ResourceList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResourceListExists(ResourceList.Id))
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

        private bool ResourceListExists(int id)
        {
            return _context.ResourceLists.Any(e => e.Id == id);
        }
    }
}
