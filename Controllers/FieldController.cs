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
    public class FieldController : Controller
    {
        private readonly DigitalOnlineShopContext _context;

        public FieldController(DigitalOnlineShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Set<Field>().Include(a =>a.Category).ToListAsync());
        }

        public IActionResult Create()
        { 
            // Get all categories from the database
            var fields = _context.Categories.ToList();

            // Pass the categories to the view using ViewBag
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CategoryId")] Field field)
        {
            if (ModelState.IsValid)
            {
                _context.Add(field);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            

            return View(field);
        }


        // other actions...
    }
}