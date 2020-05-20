using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;
using NetLearner.SharedLib.Services;

namespace NetLearner.Pages.ResourceLists
{
    public class IndexModel : PageModel
    {
        private readonly IResourceListService _resourceListService;

        public IndexModel(IResourceListService resourceListService)
        {
            _resourceListService = resourceListService;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IList<ResourceList> ResourceLists { get;set; }

        public async Task OnGetAsync()
        {
            var resourceLists = await _resourceListService.Get();

            if (!string.IsNullOrEmpty(SearchString))
            {
                ResourceLists = resourceLists.Where(s => s.Name
                    .Contains(SearchString, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
            else
            {
                ResourceLists = resourceLists;
            }
        }
    }
}
