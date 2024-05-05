using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using DigitalOnlineShop.Data;

namespace MvcPhone.Controllers
{
    public class VitrinController : Controller
    {
        private readonly DigitalOnlineShopContext _context;

        public VitrinController(DigitalOnlineShopContext context)
        {
            _context = context;
        }

        // GET: Phone

        public async Task<IActionResult> Index(string searchString, decimal? minPrice, decimal? maxPrice, int? categoryId)
        {
            var products = _context.Products.AsQueryable();
            products = products
                .Include(p => p.Category);
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");


            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
            }

            if (minPrice.HasValue)
            {
                products = products.Where(p => p.Price >= minPrice);
            }

            if (maxPrice.HasValue)
            {
                products = products.Where(p => p.Price <= maxPrice);
            }

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId);
            }

/*            if (fieldId.HasValue)
            {
                products = products.Where(s => s.FieldId == fieldId);
            }
*/  
            ViewData["currentFilter"] = searchString; // Store current filter for pre-population

            return View(await products.ToListAsync());
        }

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
    }
}