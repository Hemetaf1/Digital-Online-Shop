using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalOnlineShop.Data;
using MvcMovie.Models;
using System.Threading.Tasks;
using DigitalOnlineShop.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.Models;
using Field = Npgsql.Internal.Postgres.Field;

namespace DigitalOnlineShop.Controllers
{
    public class FieldValueController : Controller
    {
        private readonly DigitalOnlineShopContext _context;

        public FieldValueController(DigitalOnlineShopContext context)
        {
            _context = context;
        }
        
        // GET: FieldValue
        public async Task<IActionResult> Index()
        
        {

            var fieldValues = _context.FieldV
                .Include(p => p.Field)
                .Include(p => p.P)
                .AsQueryable();
           // var fieldValues = _context.FieldValues.AsQueryable();

            return View(await fieldValues.ToListAsync());
        }

        // GET: FieldValue/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldValue = await _context.FieldValues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fieldValue == null)
            {
                return NotFound();
            }

            return View(FieldValue);
        }

        // GET: FieldValue/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FieldValue/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,FieldId,Value")] FieldValue fieldValue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fieldValue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fieldValue);
        }

        // Other action methods for Edit, Delete etc. go here
    }
}