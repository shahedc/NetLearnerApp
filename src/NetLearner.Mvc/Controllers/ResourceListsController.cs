using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;
using NetLearner.SharedLib.Services;

namespace NetLearner.Mvc.Controllers
{
    public class ResourceListsController : Controller
    {
        private readonly IResourceListService _resourceListService;

        public ResourceListsController(IResourceListService resourceListService)
        {
            _resourceListService = resourceListService;
        }

        // GET: ResourceLists
        public async Task<IActionResult> Index()
        {
            return View(nameof(Index), await _resourceListService.Get());
        }

        // GET: ResourceLists/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var resourceList = await _resourceListService.Get(id);

            if (resourceList == null)
            {
                return NotFound();
            }

            return View(resourceList);
        }

        // GET: ResourceLists/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResourceLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ResourceList resourceList)
        {
            if (ModelState.IsValid)
            {
                await _resourceListService.Add(resourceList);
                return RedirectToAction(nameof(Index));
            }
            return View(resourceList);
        }

        // GET: ResourceLists/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var resourceList = await _resourceListService.Get(id);
            if (resourceList == null)
            {
                return NotFound();
            }
            return View(resourceList);
        }

        // POST: ResourceLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
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
                    await _resourceListService.Update(resourceList);
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
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var resourceList = await _resourceListService.Get(id);
            if (resourceList == null)
            {
                return NotFound();
            }

            return View(nameof(Delete), resourceList);
        }

        // POST: ResourceLists/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _resourceListService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ResourceListExists(int id)
        {
            return (_resourceListService.Get(id) != null);
        }
    }
}
