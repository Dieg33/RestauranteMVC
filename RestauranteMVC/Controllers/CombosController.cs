using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{
    public class CombosController : Controller
    {
        private readonly RestauranteDbContext _context;

        public CombosController(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var combos = await _context.Combos.ToListAsync();
            return View(combos);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComboID,Nombre,Descripcion,ImagenURL,Precio,FechaCreacion")] Combo combo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(combo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(combo);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var combo = await _context.Combos.FindAsync(id);
            if (combo == null) return NotFound();

            return View(combo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComboID,Nombre,Descripcion,ImagenURL,Precio,FechaCreacion")] Combo combo)
        {
            if (id != combo.ComboID) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(combo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(combo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var combo = await _context.Combos.FirstOrDefaultAsync(c => c.ComboID == id);
            if (combo == null) return NotFound();

            return View(combo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var combo = await _context.Combos.FindAsync(id);
            if (combo != null)
            {
                _context.Combos.Remove(combo);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
