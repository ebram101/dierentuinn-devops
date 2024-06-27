using Microsoft.AspNetCore.Mvc;
using dierentuinn.Data;
using dierentuinn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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

        public IActionResult Index()
        {
            var dierenList = _context.Dierens.Include(d => d.Category).Include(d => d.Enclosure).ToList();
            return View("./Views/Dierens/Index.cshtml", dierenList);
        }

        public IActionResult Details(int id)
        {
            var dier = _context.Dierens
                               .Include(d => d.Category)
                               .Include(d => d.Enclosure)
                               .FirstOrDefault(d => d.Id == id);
            if (dier == null)
            {
                return NotFound();
            }
            return View("./Views/Dierens/Details.cshtml", dier);
        }

        public IActionResult Create()
        {
            try
            {
                PopulateDropDownLists();
                return View("./Views/Dierens/Create.cshtml");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Create GET");
                return RedirectToAction(nameof(Index));
            }
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
            try
            {
                PopulateDropDownLists(dier);
                return View("./Views/Dierens/Create.cshtml", dier);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Create POST");
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Edit(int id)
        {
            var dier = _context.Dierens.Find(id);
            if (dier == null)
            {
                return NotFound();
            }
            try
            {
                PopulateDropDownLists(dier);
                return View("./Views/Dierens/Edit.cshtml", dier);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Edit GET");
                return RedirectToAction(nameof(Index));
            }
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
            try
            {
                PopulateDropDownLists(dier);
                return View("./Views/Dierens/Edit.cshtml", dier);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Edit POST");
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Delete(int id)
        {
            var dier = _context.Dierens
                               .Include(d => d.Category)
                               .Include(d => d.Enclosure)
                               .FirstOrDefault(d => d.Id == id);
            if (dier == null)
            {
                return NotFound();
            }
            return View("./Views/Dierens/Delete.cshtml", dier);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var dier = _context.Dierens.Find(id);
            _context.Dierens.Remove(dier);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
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

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", dier?.CategoryId);
            ViewBag.EnclosureId = new SelectList(enclosures, "Id", "Name", dier?.EnclosureId);
        }
    }
}
