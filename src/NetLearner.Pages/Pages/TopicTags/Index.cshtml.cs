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
    public class IndexModel : PageModel
    {
        private readonly NetLearner.SharedLib.Data.LibDbContext _context;

        public IndexModel(NetLearner.SharedLib.Data.LibDbContext context)
        {
            _context = context;
        }

        public IList<TopicTag> TopicTag { get;set; }

        public async Task OnGetAsync()
        {
            TopicTag = await _context.TopicTags.ToListAsync();
        }
    }
}
