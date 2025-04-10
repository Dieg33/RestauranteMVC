using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{
    public class CombosController(RestauranteDbContext context) : Controller
    {
        private readonly RestauranteDbContext _context = context;

        public IActionResult Index()
        {
            var combos = _context.Combos
                .Include(c => c.PlatosCombos!)
                .ThenInclude(pc => pc.Plato!)
                .ToList();
            return View(combos);
        }

        public IActionResult Create()
        {
            ViewBag.Platos = new MultiSelectList(_context.Platos, "PlatoID", "Nombre");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Combo combo, int[] platosSeleccionados)
        {
            if (ModelState.IsValid)
            {
                _context.Combos.Add(combo);
                _context.SaveChanges();

                foreach (var id in platosSeleccionados)
                {
                    _context.PlatosCombos.Add(new PlatosCombos
                    {
                        ComboID = combo.ComboID,
                        PlatoID = id
                    });
                }

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Platos = new MultiSelectList(_context.Platos, "PlatoID", "Nombre", platosSeleccionados);
            return View(combo);
        }

        public IActionResult Edit(int id)
        {
            var combo = _context.Combos
                .Include(c => c.PlatosCombos!)
                .FirstOrDefault(c => c.ComboID == id);

            if (combo == null) return NotFound();

            var platosSeleccionados = combo.PlatosCombos!.Select(pc => pc.PlatoID).ToArray();
            ViewBag.Platos = new MultiSelectList(_context.Platos, "PlatoID", "Nombre", platosSeleccionados);

            return View(combo);
        }

        [HttpPost]
        public IActionResult Edit(int id, Combo combo, int[] platosSeleccionados)
        {
            if (id != combo.ComboID) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Entry(combo).State = EntityState.Modified;
                _context.SaveChanges();

                var itemsAntiguos = _context.PlatosCombos.Where(pc => pc.ComboID == id);
                _context.PlatosCombos.RemoveRange(itemsAntiguos);
                _context.SaveChanges();

                foreach (var platoId in platosSeleccionados)
                {
                    _context.PlatosCombos.Add(new PlatosCombos
                    {
                        ComboID = id,
                        PlatoID = platoId
                    });
                }

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Platos = new MultiSelectList(_context.Platos, "PlatoID", "Nombre", platosSeleccionados);
            return View(combo);
        }

        public IActionResult Delete(int id)
        {
            var combo = _context.Combos
                .Include(c => c.PlatosCombos!)
                .ThenInclude(pc => pc.Plato!)
                .FirstOrDefault(c => c.ComboID == id);

            return View(combo);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var combo = _context.Combos
                .Include(c => c.PlatosCombos!)
                .FirstOrDefault(c => c.ComboID == id);

            if (combo != null)
            {
                _context.PlatosCombos.RemoveRange(combo.PlatosCombos!);
                _context.Combos.Remove(combo);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var combo = _context.Combos
                .Include(c => c.PlatosCombos!)
                .ThenInclude(pc => pc.Plato!)
                .FirstOrDefault(c => c.ComboID == id);

            return View(combo);
        }
    }
}
