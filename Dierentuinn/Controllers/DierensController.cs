using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dierentuinn.Data;
using dierentuinn.Models;

namespace dierentuinn.Controllers
{
    public class DierensController : Controller
    {
        private readonly dierentuinnContext _context;

        public DierensController(dierentuinnContext context)
        {
            _context = context;
        }

        // GET: Dierens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dieren.ToListAsync());
        }

        // GET: Dierens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dieren = await _context.Dieren
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dieren == null)
            {
                return NotFound();
            }

            return View(dieren);
        }

        // GET: Dierens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dierens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,category,size")] Dieren dieren)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dieren);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dieren);
        }

        // GET: Dierens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dieren = await _context.Dieren.FindAsync(id);
            if (dieren == null)
            {
                return NotFound();
            }
            return View(dieren);
        }

        // POST: Dierens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,category,size")] Dieren dieren)
        {
            if (id != dieren.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dieren);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DierenExists(dieren.Id))
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
            return View(dieren);
        }

        // GET: Dierens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dieren = await _context.Dieren
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dieren == null)
            {
                return NotFound();
            }

            return View(dieren);
        }

        // POST: Dierens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dieren = await _context.Dieren.FindAsync(id);
            if (dieren != null)
            {
                _context.Dieren.Remove(dieren);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DierenExists(int id)
        {
            return _context.Dieren.Any(e => e.Id == id);
        }



        // GET: Dierens/Sunrise/5
        public async Task<IActionResult> Sunrise(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dieren = await _context.Dieren
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dieren == null)
            {
                return NotFound();
            }

            string activityMessage;

            switch (dieren.ActivityPattern.ToLower())
            {
                case "diurnal":
                    activityMessage = $"{dieren.Name} wordt wakker bij zonsopgang.";
                    break;
                case "nocturnal":
                    activityMessage = $"{dieren.Name} gaat slapen bij zonsopgang.";
                    break;
                case "always active":
                    activityMessage = $"{dieren.Name} is altijd actief.";
                    break;
                default:
                    activityMessage = $"Het activiteitspatroon van {dieren.Name} is onbekend.";
                    break;
            }

            ViewBag.ActivityMessage = activityMessage;
            return View(dieren);
        }

        // Andere acties ...

        private bool DierenExist(int id)
        {
            return _context.Dieren.Any(e => e.Id == id);
        }
    }
}
