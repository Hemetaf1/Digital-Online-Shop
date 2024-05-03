using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using DigitalOnlineShop.Data;

namespace DigitalOnlineShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DigitalOnlineShopContext _context;

        public CategoryController(DigitalOnlineShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'DigitalOnlineShopContext.Category' is null.");
            }

            var categories = from m in _context.Categories
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(s => s.Name!.Contains(searchString));
            }

            return View(await categories.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,CategoryId")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,CategoryId")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
