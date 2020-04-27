using Microsoft.EntityFrameworkCore;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLearner.SharedLib.Services
{
    public class LearningResourceService : ILearningResourceService
    {
        private readonly LibDbContext _context;

        public LearningResourceService(LibDbContext context)
        {
            _context = context;
        }

        public async Task<LearningResource> Add(LearningResource learningResource)
        {
            _context.LearningResources.Add(learningResource);
            await _context.SaveChangesAsync();
            return learningResource;
        }

        public async Task<LearningResource> Delete(int id)
        {
            var learningResource = await _context.LearningResources.FindAsync(id);
            _context.LearningResources.Remove(learningResource);
            await _context.SaveChangesAsync();
            return learningResource;
        }

        public async Task<List<LearningResource>> Get()
        {
            return await _context.LearningResources.Include(r => r.ResourceList).ToListAsync();
        }


        public async Task<List<LearningResource>> GetTop(int topX)
        {
            var myItems =
            (from m in _context.LearningResources
                .Include(r => r.ResourceList)
                .TagWith($"This retrieves top {topX} Items!")
                orderby m.Id ascending
                select m)
            .Take(topX);

            return (await myItems.ToListAsync());
        }

        public async Task<List<LearningResource>> GetForList(int resourceListId)
        {
            var results =  _context.LearningResources
                .Where(lr => lr.ResourceListId == resourceListId)
                .Include(r => r.ResourceList);

            return await results.ToListAsync();
        }

        public async Task<LearningResource> Get(int id)
        {
            var learningResource = await _context.LearningResources
                .Include(r => r.ResourceList)
                .FirstOrDefaultAsync(m => m.Id == id);

            return learningResource;
        }

        public async Task<LearningResource> Update(LearningResource learningResource)
        {
            _context.Entry(learningResource).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return learningResource;
        }
    }
}
