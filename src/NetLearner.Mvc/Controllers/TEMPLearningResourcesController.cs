using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;

namespace NetLearner.Mvc.Controllers
{
    public class TEMPLearningResourcesController : Controller
    {
        private readonly LibDbContext _context;

        public TEMPLearningResourcesController(LibDbContext context)
        {
            _context = context;
        }

        // GET: TEMPLearningResources
        public async Task<IActionResult> Index()
        {
            var libDbContext = _context.LearningResources.Include(l => l.ResourceList);
            return View(await libDbContext.ToListAsync());
        }

        // GET: TEMPLearningResources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningResource = await _context.LearningResources
                .Include(l => l.ResourceList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learningResource == null)
            {
                return NotFound();
            }

            return View(learningResource);
        }

        // GET: TEMPLearningResources/Create
        public IActionResult Create()
        {
            ViewData["ResourceListId"] = new SelectList(_context.Set<ResourceList>(), "Id", "Id");
            return View();
        }

        // POST: TEMPLearningResources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Url,ResourceListId")] LearningResource learningResource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learningResource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResourceListId"] = new SelectList(_context.Set<ResourceList>(), "Id", "Id", learningResource.ResourceListId);
            return View(learningResource);
        }

        // GET: TEMPLearningResources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningResource = await _context.LearningResources.FindAsync(id);
            if (learningResource == null)
            {
                return NotFound();
            }
            ViewData["ResourceListId"] = new SelectList(_context.Set<ResourceList>(), "Id", "Id", learningResource.ResourceListId);
            return View(learningResource);
        }

        // POST: TEMPLearningResources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Url,ResourceListId")] LearningResource learningResource)
        {
            if (id != learningResource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learningResource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearningResourceExists(learningResource.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var resourceList = _context.Set<ResourceList>();
            ViewData["ResourceListId"] = new SelectList(resourceList, "Id", "Id", learningResource.ResourceListId);
            return View(learningResource);
        }

        // GET: TEMPLearningResources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningResource = await _context.LearningResources
                .Include(l => l.ResourceList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learningResource == null)
            {
                return NotFound();
            }

            return View(learningResource);
        }

        // POST: TEMPLearningResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learningResource = await _context.LearningResources.FindAsync(id);
            _context.LearningResources.Remove(learningResource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearningResourceExists(int id)
        {
            return _context.LearningResources.Any(e => e.Id == id);
        }
    }
}
