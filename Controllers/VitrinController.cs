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
        public async Task<IActionResult> Index(string searchString, decimal? minPrice, decimal? maxPrice)
        {
            var products = from m in _context.Products
                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name!.Contains(searchString));
            }

            if (minPrice.HasValue)
            {
                products = products.Where(p => p.Price >= minPrice);
            }

            if (maxPrice.HasValue)
            {
                products = products.Where(p => p.Price <= maxPrice);
            }
/*       if (!String.IsNullOrEmpty(Category))
        {
            products = products.Where(s => s.Category.Contains(Category));
        } */
/* Search by Field
        if (!String.IsNullOrEmpty(searchString))
        {
            products = products.Where(s => s.Name!.Contains(searchString));
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