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

        public async Task<ResourceList> Add(ResourceList resourceList)
        {
            _context.ResourceLists.Add(resourceList);
            await _context.SaveChangesAsync();
            return resourceList;
        }

        public async Task<ResourceList> Delete(int id)
        {
            var resourceList = await _context.ResourceLists.FindAsync(id);
            _context.ResourceLists.Remove(resourceList);
            await _context.SaveChangesAsync();
            return resourceList;
        }

        public async Task<List<ResourceList>> Get()
        {
            return await _context.ResourceLists.ToListAsync();
        }

        public async Task<ResourceList> Get(int id)
        {
            var resourceList = await _context.ResourceLists.FindAsync(id);

            return resourceList;
        }

        public async Task<ResourceList> Update(ResourceList resourceList)
        {
            _context.Entry(resourceList).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return resourceList;
        }
    }
}
