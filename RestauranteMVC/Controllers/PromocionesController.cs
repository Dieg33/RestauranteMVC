using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{
    public class PromocionesController : Controller
    {
        private readonly RestauranteDbContext _context;
        public PromocionesController(RestauranteDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var promociones = _context.Promociones
                .Include(p => p.Promociones_Items)
                .ThenInclude(pi => pi.Plato)
                .Include(p => p.Promociones_Items)
                .ThenInclude(pi => pi.Combo)
                .ToList();
            return View(promociones);
        }
        public IActionResult Create()
        {
            ViewBag.Platos = new SelectList(_context.Platos, "PlatoID", "Nombre");
            ViewBag.Combos = new SelectList(_context.Combos, "ComboID", "Nombre");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Promociones promocion, int[] platosSeleccionados, int[] combosSeleccionados)
        {
            if (ModelState.IsValid)
            {
                _context.Promociones.Add(promocion);
                _context.SaveChanges();
                // Agregar promociones seleccionadas
                if (platosSeleccionados != null)
                {
                    foreach (var platId in platosSeleccionados)
                    {
                        _context.Promociones_Items.Add(new Promociones_Items { PromocionID = promocion.PromocionID, PlatoID = platId });
                    }
                }
                
                if (combosSeleccionados != null)
                {
                    foreach (var comboId in combosSeleccionados)
                    {
                        _context.Promociones_Items.Add(new Promociones_Items { PromocionID = promocion.PromocionID, ComboID = comboId });
                    }
                }
                

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Platos = _context.Platos.ToList();
            ViewBag.Combos = _context.Combos.ToList();
            return View(promocion);
        }
        public async Task<ActionResult> Edit(int? id)
        {
            var promo = await _context.Promociones
                .Include(m => m.Promociones_Items)
                .FirstOrDefaultAsync(m => m.PromocionID == id);

            if (promo == null)
            {
                return NotFound();
            }

            // Obtener todos los platos y combos
            var platos = _context.Platos.ToList();
            var combos = _context.Combos.ToList();

            // Obtener los elementos ya seleccionados en esta promo
            var platosSeleccionados = promo.Promociones_Items.Where(mi => mi.PlatoID.HasValue).Select(mi => mi.PlatoID.Value).ToList();
            var combosSeleccionados = promo.Promociones_Items.Where(mi => mi.ComboID.HasValue).Select(mi => mi.ComboID.Value).ToList();

            // Convertir a SelectList con selección previa

            ViewBag.Platos = platos.Select(p => new SelectListItem
            {
                Value = p.PlatoID.ToString(),
                Text = p.Nombre,
                Selected = platosSeleccionados.Contains(p.PlatoID)
            }).ToList();

            ViewBag.Combos = combos.Select(c => new SelectListItem
            {
                Value = c.ComboID.ToString(),
                Text = c.Nombre,
                Selected = combosSeleccionados.Contains(c.ComboID)
            }).ToList();

            return View(promo);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Promociones promocion, int[] platosSeleccionados, int[] combosSeleccionados)
        {

            if (id != promocion.PromocionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(promocion).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    // Eliminar registros antiguos de Menu_Items
                    var itemsExistentes = _context.Promociones_Items.Where(m => m.PromocionID == id);
                    _context.Promociones_Items.RemoveRange(itemsExistentes);
                    await _context.SaveChangesAsync();

                    // Agregar nuevas asociaciones en Menu_Items

                    if (platosSeleccionados != null)
                    {
                        foreach (var platoId in platosSeleccionados)
                        {
                            _context.Promociones_Items.Add(new Promociones_Items { PromocionID = id, PlatoID = platoId });
                        }
                    }

                    if (combosSeleccionados != null)
                    {
                        foreach (var comboId in combosSeleccionados)
                        {
                            _context.Promociones_Items.Add(new Promociones_Items { PromocionID = id, ComboID = comboId });
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Promociones.Any(m => m.PromocionID == id))
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

            return View(promocion);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocion = await _context.Promociones
            .Include(p => p.Promociones_Items)
           .ThenInclude(pi => pi.Plato)
            .Include(p => p.Promociones_Items)
           .ThenInclude(pi => pi.Combo)
            .FirstOrDefaultAsync(m => m.PromocionID == id);

            if (promocion == null)
            {
                return NotFound();
            }

            return View(promocion);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocion = await _context.Promociones
                .Include(p => p.Promociones_Items)
                .FirstOrDefaultAsync(m => m.PromocionID == id);

            if (promocion != null)
            {
                _context.Promociones_Items.RemoveRange(promocion.Promociones_Items);
                _context.Promociones.Remove(promocion);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var promocion = await _context.Promociones
                .Include(p => p.Promociones_Items)
                    .ThenInclude(pi => pi.Plato)
                .Include(p => p.Promociones_Items)
                    .ThenInclude(pi => pi.Combo)
                .FirstOrDefaultAsync(m => m.PromocionID == id);

            if (promocion == null) return NotFound();

            return View(promocion);
        }
        private bool promocionExiste(int id)
        {
            return _context.Promociones.Any(e => e.PromocionID == id);
        }
    }
}
