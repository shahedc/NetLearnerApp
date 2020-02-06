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
    public class TopicTagsController : Controller
    {
        private readonly LibDbContext _context;

        public TopicTagsController(LibDbContext context)
        {
            _context = context;
        }

        // GET: TopicTags
        public async Task<IActionResult> Index()
        {
            return View(await _context.TopicTags.ToListAsync());
        }

        // GET: TopicTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicTag = await _context.TopicTags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topicTag == null)
            {
                return NotFound();
            }

            return View(topicTag);
        }

        // GET: TopicTags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TopicTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TagValue")] TopicTag topicTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topicTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(topicTag);
        }

        // GET: TopicTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicTag = await _context.TopicTags.FindAsync(id);
            if (topicTag == null)
            {
                return NotFound();
            }
            return View(topicTag);
        }

        // POST: TopicTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TagValue")] TopicTag topicTag)
        {
            if (id != topicTag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topicTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicTagExists(topicTag.Id))
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
            return View(topicTag);
        }

        // GET: TopicTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicTag = await _context.TopicTags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topicTag == null)
            {
                return NotFound();
            }

            return View(topicTag);
        }

        // POST: TopicTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topicTag = await _context.TopicTags.FindAsync(id);
            _context.TopicTags.Remove(topicTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicTagExists(int id)
        {
            return _context.TopicTags.Any(e => e.Id == id);
        }
    }
}
