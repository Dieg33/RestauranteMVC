using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly RestauranteDbContext _context;
        public MenuController(RestauranteDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menu
                 .Include(m => m.Menu_Items)
                 .ThenInclude(mi => mi.Promociones)
                 .Include(m => m.Menu_Items)
                 .ThenInclude(mi => mi.Platos)
                 .Include(m => m.Menu_Items)
                 .ThenInclude(mi => mi.Combos)
                 .ToListAsync();

            return View(menus);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Promociones = new SelectList(await _context.Promociones.ToListAsync(), "PromocionID", "Descripcion");
            ViewBag.Combos = new SelectList(await _context.Combos.ToListAsync(), "ComboID", "Nombre");
            ViewBag.Platos = new SelectList(await _context.Platos.ToListAsync(), "PlatoID", "Nombre");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Menu menu, int[] promocionesSeleccionadas, int[] platosSeleccionados, int[] combosSeleccionados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();

                // Agregar promociones seleccionadas
                if (promocionesSeleccionadas != null)
                {
                    foreach (var promoId in promocionesSeleccionadas)
                    {
                        _context.Menu_Items.Add(new Menu_Items { MenuID = menu.MenuID, PromocionID = promoId });
                    }
                }

                // Agregar platos seleccionados
                if (platosSeleccionados != null)
                {
                    foreach (var platoId in platosSeleccionados)
                    {
                        _context.Menu_Items.Add(new Menu_Items { MenuID = menu.MenuID, PlatoID = platoId });
                    }
                }

                // Agregar combos seleccionados
                if (combosSeleccionados != null)
                {
                    foreach (var comboId in combosSeleccionados)
                    {
                        _context.Menu_Items.Add(new Menu_Items { MenuID = menu.MenuID, ComboID = comboId });
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(menu);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var menu = await _context.Menu
                .Include(m => m.Menu_Items)
                .FirstOrDefaultAsync(m => m.MenuID == id);

            if (menu == null)
            {
                return NotFound();
            }

            // Obtener todas las promociones, platos y combos
            var promociones = _context.Promociones.ToList();
            var platos = _context.Platos.ToList();
            var combos = _context.Combos.ToList();

            // Obtener los elementos ya seleccionados en este menú
            var promocionesSeleccionadas = menu.Menu_Items.Where(mi => mi.PromocionID.HasValue).Select(mi => mi.PromocionID.Value).ToList();
            var platosSeleccionados = menu.Menu_Items.Where(mi => mi.PlatoID.HasValue).Select(mi => mi.PlatoID.Value).ToList();
            var combosSeleccionados = menu.Menu_Items.Where(mi => mi.ComboID.HasValue).Select(mi => mi.ComboID.Value).ToList();

            // Convertir a SelectList con selección previa
            ViewBag.Promociones = promociones.Select(p => new SelectListItem
            {
                Value = p.PromocionID.ToString(),
                Text = p.Descripcion,
                Selected = promocionesSeleccionadas.Contains(p.PromocionID)
            }).ToList();

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

            return View(menu);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Menu menu, int[] promocionesSeleccionadas, int[] platosSeleccionados, int[] combosSeleccionados)
        {
            if (id != menu.MenuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(menu).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    // Eliminar registros antiguos de Menu_Items
                    var itemsExistentes = _context.Menu_Items.Where(m => m.MenuID == id);
                    _context.Menu_Items.RemoveRange(itemsExistentes);
                    await _context.SaveChangesAsync();

                    // Agregar nuevas asociaciones en Menu_Items
                    if (promocionesSeleccionadas != null)
                    {
                        foreach (var promoId in promocionesSeleccionadas)
                        {
                            _context.Menu_Items.Add(new Menu_Items { MenuID = id, PromocionID = promoId });
                        }
                    }

                    if (platosSeleccionados != null)
                    {
                        foreach (var platoId in platosSeleccionados)
                        {
                            _context.Menu_Items.Add(new Menu_Items { MenuID = id, PlatoID = platoId });
                        }
                    }

                    if (combosSeleccionados != null)
                    {
                        foreach (var comboId in combosSeleccionados)
                        {
                            _context.Menu_Items.Add(new Menu_Items { MenuID = id, ComboID = comboId });
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Menu.Any(m => m.MenuID == id))
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

            return View(menu);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var menu = await _context.Menu
                .Include(m => m.Menu_Items)
                .ThenInclude(mi => mi.Promociones)
                .Include(m => m.Menu_Items)
                .ThenInclude(mi => mi.Platos)
                .Include(m => m.Menu_Items)
                .ThenInclude(mi => mi.Combos)
                .FirstOrDefaultAsync(m => m.MenuID == id);

            if (menu == null) return NotFound();

            return View(menu);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu
                .FirstOrDefaultAsync(m => m.MenuID == id);

            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menu
                .Include(m => m.Menu_Items)
                .FirstOrDefaultAsync(m => m.MenuID == id);

            if (menu == null)
            {
                return NotFound();
            }

            // Eliminar los elementos asociados en Menu_Items
            _context.Menu_Items.RemoveRange(menu.Menu_Items);

            // Eliminar el menú
            _context.Menu.Remove(menu);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        private bool MenuExiste(int id)
        {
            return _context.Menu.Any(e => e.MenuID == id);
        }
    }
}
