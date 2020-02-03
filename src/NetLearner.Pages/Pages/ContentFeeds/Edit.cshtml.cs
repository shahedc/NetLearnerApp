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

namespace NetLearner.Pages.ContentFeeds
{
    public class EditModel : PageModel
    {
        private readonly NetLearner.SharedLib.Data.LibDbContext _context;

        public EditModel(NetLearner.SharedLib.Data.LibDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["LearningResourceId"] = new SelectList(_context.LearningResources, "Id", "Id");
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

            _context.Attach(ContentFeed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentFeedExists(ContentFeed.Id))
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

        private bool ContentFeedExists(int id)
        {
            return _context.ContentFeeds.Any(e => e.Id == id);
        }
    }
}
