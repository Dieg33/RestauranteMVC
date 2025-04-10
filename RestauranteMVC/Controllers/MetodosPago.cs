using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{
    public class MetodosPagoController : Controller
    {
        private readonly RestauranteDbContext _context;

        public MetodosPagoController(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index() => View(await _context.MetodoPagos.ToListAsync());

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MetodoID,Nombre,Descripcion")] MetodoPago metodo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metodo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metodo);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var metodo = await _context.MetodoPagos.FindAsync(id);
            if (metodo == null) return NotFound();

            return View(metodo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MetodoID,Nombre,Descripcion")] MetodoPago metodo)
        {
            if (id != metodo.MetodoID) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(metodo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metodo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var metodo = await _context.MetodoPagos.FirstOrDefaultAsync(m => m.MetodoID == id);
            if (metodo == null) return NotFound();

            return View(metodo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metodo = await _context.MetodoPagos.FindAsync(id);
            _context.MetodoPagos.Remove(metodo!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
