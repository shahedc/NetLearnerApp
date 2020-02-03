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
    public class ContentFeedsController : Controller
    {
        private readonly LibDbContext _context;

        public ContentFeedsController(LibDbContext context)
        {
            _context = context;
        }

        // GET: ContentFeeds
        public async Task<IActionResult> Index()
        {
            var libDbContext = _context.ContentFeeds.Include(c => c.LearningResource);
            return View(await libDbContext.ToListAsync());
        }

        // GET: ContentFeeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentFeed = await _context.ContentFeeds
                .Include(c => c.LearningResource)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contentFeed == null)
            {
                return NotFound();
            }

            return View(contentFeed);
        }

        // GET: ContentFeeds/Create
        public IActionResult Create()
        {
            ViewData["LearningResourceId"] = new SelectList(_context.LearningResources, "Id", "Id");
            return View();
        }

        // POST: ContentFeeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FeedUrl,LearningResourceId")] ContentFeed contentFeed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contentFeed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LearningResourceId"] = new SelectList(_context.LearningResources, "Id", "Id", contentFeed.LearningResourceId);
            return View(contentFeed);
        }

        // GET: ContentFeeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentFeed = await _context.ContentFeeds.FindAsync(id);
            if (contentFeed == null)
            {
                return NotFound();
            }
            ViewData["LearningResourceId"] = new SelectList(_context.LearningResources, "Id", "Id", contentFeed.LearningResourceId);
            return View(contentFeed);
        }

        // POST: ContentFeeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FeedUrl,LearningResourceId")] ContentFeed contentFeed)
        {
            if (id != contentFeed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contentFeed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentFeedExists(contentFeed.Id))
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
            ViewData["LearningResourceId"] = new SelectList(_context.LearningResources, "Id", "Id", contentFeed.LearningResourceId);
            return View(contentFeed);
        }

        // GET: ContentFeeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentFeed = await _context.ContentFeeds
                .Include(c => c.LearningResource)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contentFeed == null)
            {
                return NotFound();
            }

            return View(contentFeed);
        }

        // POST: ContentFeeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contentFeed = await _context.ContentFeeds.FindAsync(id);
            _context.ContentFeeds.Remove(contentFeed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContentFeedExists(int id)
        {
            return _context.ContentFeeds.Any(e => e.Id == id);
        }
    }
}
