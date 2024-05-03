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
        var phones = from m in _context.Products
                    select m;

        if (!String.IsNullOrEmpty(searchString))
        {
            phones = phones.Where(s => s.Name!.Contains(searchString));
        }

        if (minPrice.HasValue)
        {
            phones = phones.Where(p => p.Price >= minPrice);
        }

        if (maxPrice.HasValue)
        {
            phones = phones.Where(p => p.Price <= maxPrice);
        }

        ViewData["currentFilter"] = searchString; // Store current filter for pre-population

        return View(await phones.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var phone = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
        if (phone == null)
        {
            return NotFound();
        }

        return View(phone);
    }
}

}