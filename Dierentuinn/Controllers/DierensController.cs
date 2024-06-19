using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using dierentuinn.Data;
using dierentuinn.Models;

namespace dierentuinn.Controllers
{
    public class DierenController : Controller
    {
        private readonly DierentuinnContext _context;

        public DierenController(DierentuinnContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dieren = await _context.Dierens
                .Include(d => d.Category)
                .Include(d => d.Enclosure)
                .ToListAsync();
            return View(dieren);
        }

        public async Task<IActionResult> Details(int id)
        {
            var dier = await _context.Dierens
                .Include(d => d.Category)
                .Include(d => d.Enclosure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dier == null)
            {
                return NotFound();
            }
            return View(dier);
        }

        public IActionResult Create()
        {
            ViewData["Categories"] = _context.Categories.ToList();
            ViewData["Enclosures"] = _context.Enclosures.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Species,CategoryId,Size,DietaryClass,ActivityPattern,Prey,EnclosureId,SpaceRequirement,SecurityRequirement")] Dieren dier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categories"] = _context.Categories.ToList();
            ViewData["Enclosures"] = _context.Enclosures.ToList();
            return View(dier);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dier = await _context.Dierens.FindAsync(id);
            if (dier == null)
            {
                return NotFound();
            }
            ViewData["Categories"] = _context.Categories.ToList();
            ViewData["Enclosures"] = _context.Enclosures.ToList();
            return View(dier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Species,CategoryId,Size,DietaryClass,ActivityPattern,Prey,EnclosureId,SpaceRequirement,SecurityRequirement")] Dieren dier)
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
            ViewData["Categories"] = _context.Categories.ToList();
            ViewData["Enclosures"] = _context.Enclosures.ToList();
            return View(dier);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dier = await _context.Dierens
                .Include(d => d.Category)
                .Include(d => d.Enclosure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dier == null)
            {
                return NotFound();
            }

            return View(dier);
        }

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
    }
}
