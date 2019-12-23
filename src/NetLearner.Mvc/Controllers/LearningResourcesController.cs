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
    public class LearningResourcesController : Controller
    {
        private readonly LibDbContext _context;

        public LearningResourcesController(LibDbContext context)
        {
            _context = context;
        }

        // GET: LearningResources
        public async Task<IActionResult> Index()
        {
            return View(await _context.LearningResources.ToListAsync());
        }

        // GET: LearningResources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningResource = await _context.LearningResources
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learningResource == null)
            {
                return NotFound();
            }

            return View(learningResource);
        }

        // GET: LearningResources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LearningResources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Url")] LearningResource learningResource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learningResource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(learningResource);
        }

        // GET: LearningResources/Edit/5
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
            return View(learningResource);
        }

        // POST: LearningResources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Url")] LearningResource learningResource)
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
            return View(learningResource);
        }

        // GET: LearningResources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningResource = await _context.LearningResources
                .FirstOrDefaultAsync(m => m.Id == id);
            if (learningResource == null)
            {
                return NotFound();
            }

            return View(learningResource);
        }

        // POST: LearningResources/Delete/5
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
