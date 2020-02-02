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
    public class IndexModel : PageModel
    {
        private readonly NetLearner.SharedLib.Data.LibDbContext _context;

        public IndexModel(NetLearner.SharedLib.Data.LibDbContext context)
        {
            _context = context;
        }

        public IList<ContentFeed> ContentFeed { get;set; }

        public async Task OnGetAsync()
        {
            ContentFeed = await _context.ContentFeeds
                .Include(c => c.LearningResource).ToListAsync();
        }
    }
}
