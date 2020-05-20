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
    public class DetailsModel : PageModel
    {
        private readonly NetLearner.SharedLib.Data.LibDbContext _context;

        public DetailsModel(NetLearner.SharedLib.Data.LibDbContext context)
        {
            _context = context;
        }

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
    }
}
