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

namespace NetLearner.Pages.TopicTags
{
    public class EditModel : PageModel
    {
        private readonly NetLearner.SharedLib.Data.LibDbContext _context;

        public EditModel(NetLearner.SharedLib.Data.LibDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TopicTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicTagExists(TopicTag.Id))
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

        private bool TopicTagExists(int id)
        {
            return _context.TopicTags.Any(e => e.Id == id);
        }
    }
}
