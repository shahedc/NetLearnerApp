using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;

namespace NetLearner.Pages.ContentFeeds
{
    public class DetailsModel : PageModel
    {
        private readonly NetLearner.SharedLib.Data.LibDbContext _context;

        public DetailsModel(NetLearner.SharedLib.Data.LibDbContext context)
        {
            _context = context;
        }

        public ContentFeed ContentFeed { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContentFeed = await _context.ContentFeeds
                .Include(c => c.LearningResource).FirstOrDefaultAsync(m => m.Id == id);

            if (ContentFeed == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
