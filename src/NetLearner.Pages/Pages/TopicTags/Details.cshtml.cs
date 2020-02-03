using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;

namespace NetLearner.Pages.TopicTags
{
    public class DetailsModel : PageModel
    {
        private readonly NetLearner.SharedLib.Data.LibDbContext _context;

        public DetailsModel(NetLearner.SharedLib.Data.LibDbContext context)
        {
            _context = context;
        }

        public TopicTag TopicTag { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TopicTag = await _context.TopicTags.FirstOrDefaultAsync(m => m.Id == id);

            if (TopicTag == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
