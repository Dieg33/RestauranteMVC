using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{
    public class PlatosCombosController : Controller
    {
        private readonly RestauranteDbContext _context;

        public PlatosCombosController(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var relaciones = _context.PlatosCombos
                .Include(pc => pc.Plato)
                .Include(pc => pc.Combo);
            return View(await relaciones.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["ComboID"] = new SelectList(_context.Combos, "ComboID", "Nombre");
            ViewData["PlatoID"] = new SelectList(_context.Platos, "PlatoID", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComboID,PlatoID")] PlatosCombos pc)
        {
            if (!_context.PlatosCombos.Any(x => x.ComboID == pc.ComboID && x.PlatoID == pc.PlatoID))
            {
                _context.Add(pc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Este platillo ya está asociado a este combo.");
            ViewData["ComboID"] = new SelectList(_context.Combos, "ComboID", "Nombre", pc.ComboID);
            ViewData["PlatoID"] = new SelectList(_context.Platos, "PlatoID", "Nombre", pc.PlatoID);
            return View(pc);
        }

        public async Task<IActionResult> Delete(int? comboID, int? platoID)
        {
            if (comboID == null || platoID == null) return NotFound();

            var pc = await _context.PlatosCombos
                .Include(p => p.Plato)
                .Include(c => c.Combo)
                .FirstOrDefaultAsync(m => m.ComboID == comboID && m.PlatoID == platoID);

            if (pc == null) return NotFound();

            return View(pc);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int comboID, int platoID)
        {
            var pc = await _context.PlatosCombos.FindAsync(comboID, platoID);
            if (pc != null)
            {
                _context.PlatosCombos.Remove(pc);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
