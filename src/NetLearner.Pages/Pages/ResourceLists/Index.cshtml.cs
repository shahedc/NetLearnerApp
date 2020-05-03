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
    public class IndexModel : PageModel
    {
        private readonly NetLearner.SharedLib.Data.LibDbContext _context;

        public IndexModel(NetLearner.SharedLib.Data.LibDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IList<ResourceList> ResourceList { get;set; }

        public async Task OnGetAsync()
        {
            var resourceLists = from rs in _context.ResourceLists
                         select rs;
            if (!string.IsNullOrEmpty(SearchString))
            {
                resourceLists = resourceLists.Where(s => s.Name.Contains(SearchString));
            }

            ResourceList = await resourceLists.ToListAsync();
        }
    }
}
