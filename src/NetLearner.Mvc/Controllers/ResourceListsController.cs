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
    public class ResourceListsController : Controller
    {
        private readonly LibDbContext _context;

        public ResourceListsController(LibDbContext context)
        {
            _context = context;
        }

        // GET: ResourceLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResourceLists.ToListAsync());
        }

        // GET: ResourceLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceList = await _context.ResourceLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resourceList == null)
            {
                return NotFound();
            }

            return View(resourceList);
        }

        // GET: ResourceLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResourceLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ResourceList resourceList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resourceList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resourceList);
        }

        // GET: ResourceLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceList = await _context.ResourceLists.FindAsync(id);
            if (resourceList == null)
            {
                return NotFound();
            }
            return View(resourceList);
        }

        // POST: ResourceLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ResourceList resourceList)
        {
            if (id != resourceList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resourceList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourceListExists(resourceList.Id))
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
            return View(resourceList);
        }

        // GET: ResourceLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resourceList = await _context.ResourceLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resourceList == null)
            {
                return NotFound();
            }

            return View(resourceList);
        }

        // POST: ResourceLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resourceList = await _context.ResourceLists.FindAsync(id);
            _context.ResourceLists.Remove(resourceList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResourceListExists(int id)
        {
            return _context.ResourceLists.Any(e => e.Id == id);
        }
    }
}
