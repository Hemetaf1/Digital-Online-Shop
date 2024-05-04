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
    public class ProductController : Controller
    {
        private readonly DigitalOnlineShopContext _context;
        
        public ProductController(DigitalOnlineShopContext context)
        {
            _context = context;
        }

        // GET: Phone
        
        public async Task<IActionResult> Index(string searchString)
        {
                 if (_context.Products == null)
                {
                    return Problem("Entity set 'MvcMovieContext.Phone'  is null.");
                }

                var products = from m in _context.Products
                            select m;
                _context.Set<Product>().Include(a=>a.Category).ToList();

                if (!String.IsNullOrEmpty(searchString))
                {
                    products = products.Where(s => s.Name!.Contains(searchString));
                }

                return View(await products.ToListAsync());
            
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        
        // GET: Product/Create
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<JsonResult> GetFields(int categoryId)
        {
            var fields = await _context.Fields.Where(f => f.CategoryId == categoryId).ToListAsync();
            return Json(fields);
        }
        
        
        
        
        
        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Phone/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price, CategoryId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            
               
                var product2 = await _context.Products.FindAsync(id);
                if (product2 == null)
                {
                    return NotFound();
                }
                ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product2);
        }

        // GET: Phone/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Phone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int? id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
