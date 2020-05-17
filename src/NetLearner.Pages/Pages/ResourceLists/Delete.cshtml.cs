using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;

namespace NetLearner.Pages.ResourceLists
{
    public class DeleteModel : PageModel
    {
        private readonly NetLearner.SharedLib.Data.LibDbContext _context;

        public DeleteModel(NetLearner.SharedLib.Data.LibDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ResourceList = await _context.ResourceLists.FindAsync(id);

            if (ResourceList != null)
            {
                _context.ResourceLists.Remove(ResourceList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
