using Microsoft.EntityFrameworkCore;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;
using System;
using System.Collections.Generic;
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

        public async Task<LearningResource> Add(LearningResource cinematicItem)
        {
            _context.LearningResources.Add(cinematicItem);
            await _context.SaveChangesAsync();
            return cinematicItem;
        }

        public async Task<LearningResource> Delete(int id)
        {
            var cinematicItem = await _context.LearningResources.FindAsync(id);
            _context.LearningResources.Remove(cinematicItem);
            await _context.SaveChangesAsync();
            return cinematicItem;
        }

        public async Task<List<LearningResource>> Get()
        {
            return await _context.LearningResources.ToListAsync();
        }

        public async Task<LearningResource> Get(int id)
        {
            var toDo = await _context.LearningResources.FindAsync(id);
            return toDo;
        }

        public async Task<LearningResource> Update(LearningResource cinematicItem)
        {
            _context.Entry(cinematicItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cinematicItem;
        }
    }
}
