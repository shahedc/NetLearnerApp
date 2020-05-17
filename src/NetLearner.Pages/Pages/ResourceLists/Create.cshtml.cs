using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;

namespace NetLearner.Pages.ResourceLists
{
    public class CreateModel : PageModel
    {
        private readonly NetLearner.SharedLib.Data.LibDbContext _context;

        public CreateModel(NetLearner.SharedLib.Data.LibDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ResourceList ResourceList { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ResourceLists.Add(ResourceList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
