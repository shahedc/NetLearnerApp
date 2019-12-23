using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;

namespace NetLearner.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly NetLearner.SharedLib.Data.LibDbContext _context;

        public DetailsModel(NetLearner.SharedLib.Data.LibDbContext context)
        {
            _context = context;
        }

        public LearningResource LearningResource { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LearningResource = await _context.LearningResources.FirstOrDefaultAsync(m => m.Id == id);

            if (LearningResource == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
