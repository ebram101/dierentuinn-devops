using Microsoft.AspNetCore.Mvc;
using dierentuinn.Data;
using dierentuinn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace dierentuinn.Controllers
{
    public class DierenController : Controller
    {
        private readonly DierentuinDbContext _context;
        private readonly ILogger<DierenController> _logger;

        public DierenController(DierentuinDbContext context, ILogger<DierenController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Dieren
        public async Task<IActionResult> Index()
        {
            var dierenList = await _context.Dierens.Include(d => d.Category).Include(d => d.Enclosure).ToListAsync();
            return View("./Views/Dierens/Index.cshtml", dierenList);
        }

        // GET: Dieren/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dier = await _context.Dierens
                .Include(d => d.Category)
                .Include(d => d.Enclosure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dier == null)
            {
                return NotFound();
            }

            return View("./Views/Dierens/Details.cshtml", dier);
        }

        // GET: Dieren/Create
        public IActionResult Create()
        {
            PopulateDropDownLists();
            return View("./Views/Dierens/Create.cshtml");
        }

        // POST: Dieren/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Species,CategoryId,Description,EnclosureId")] Dieren dier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDropDownLists(dier);
            return View("./Views/Dierens/Create.cshtml", dier);
        }

        // GET: Dieren/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dier = await _context.Dierens.FindAsync(id);
            if (dier == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(dier);
            return View("./Views/Dierens/Edit.cshtml", dier);
        }

        // POST: Dieren/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Species,CategoryId,Description,EnclosureId")] Dieren dier)
        {
            if (id != dier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DierenExists(dier.Id))
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
            PopulateDropDownLists(dier);
            return View("./Views/Dierens/Edit.cshtml", dier);
        }

        // GET: Dieren/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dier = await _context.Dierens
                .Include(d => d.Category)
                .Include(d => d.Enclosure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dier == null)
            {
                return NotFound();
            }

            return View("./Views/Dierens/Delete.cshtml", dier);
        }

        // POST: Dieren/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dier = await _context.Dierens.FindAsync(id);
            _context.Dierens.Remove(dier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DierenExists(int id)
        {
            return _context.Dierens.Any(e => e.Id == id);
        }

        private void PopulateDropDownLists(Dieren dier = null)
        {
            var categories = _context.Categories?.ToList() ?? new List<Category>();
            var enclosures = _context.Enclosures?.ToList() ?? new List<Enclosure>();

            if (!categories.Any())
            {
                _logger.LogWarning("Categories collection is empty");
            }

            if (!enclosures.Any())
            {
                _logger.LogWarning("Enclosures collection is empty");
            }

            // Populate ViewBag for dropdown lists
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", dier?.CategoryId);
            ViewBag.EnclosureId = new SelectList(enclosures, "Id", "Name", dier?.EnclosureId);
        }
    }
}
