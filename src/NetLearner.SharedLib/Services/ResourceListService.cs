using Microsoft.EntityFrameworkCore;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetLearner.SharedLib.Services
{
    public class ResourceListService: IResourceListService
    {
        private readonly LibDbContext _context;

        public ResourceListService(LibDbContext context)
        {
            _context = context;
        }
        public async Task<List<ResourceList>> Get()
        {
            return await _context.ResourceLists.ToListAsync();
        }
    }
}
