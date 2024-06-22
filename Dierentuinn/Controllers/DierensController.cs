using Microsoft.AspNetCore.Mvc;
using dierentuinn.Data;
using dierentuinn.Models;
using System.Linq;
using System.Threading.Tasks;

namespace dierentuinn.Controllers
{
    public class DierenController : Controller
    {
        private readonly DierentuinDbContext _context;

        public DierenController(DierentuinDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Dierens.ToList());
        }

        public IActionResult Details(int id)
        {
            var dier = _context.Dierens.FirstOrDefault(d => d.Id == id);
            if (dier == null)
            {
                return NotFound();
            }
            return View(dier);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Dieren dier)
        {
            if (ModelState.IsValid)
            {
                _context.Dierens.Add(dier);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(dier);
        }

        public IActionResult Edit(int id)
        {
            var dier = _context.Dierens.Find(id);
            if (dier == null)
            {
                return NotFound();
            }
            return View(dier);
        }

        [HttpPost]
        public IActionResult Edit(Dieren dier)
        {
            if (ModelState.IsValid)
            {
                _context.Update(dier);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(dier);
        }

        public IActionResult Delete(int id)
        {
            var dier = _context.Dierens.Find(id);
            if (dier == null)
            {
                return NotFound();
            }
            return View(dier);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var dier = _context.Dierens.Find(id);
            _context.Dierens.Remove(dier);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
