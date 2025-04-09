using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly RestauranteDbContext _context;

        public EmpleadosController(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var empleados = _context.Empleados.Include(e => e.Rol);
            return View(await empleados.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.Empleados
                .Include(e => e.Rol)
                .FirstOrDefaultAsync(m => m.EmpleadoID == id);

            if (empleado == null) return NotFound();

            return View(empleado);
        }

        public IActionResult Create()
        {
            ViewData["RolID"] = new SelectList(_context.Rol, "RolID", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpleadoID,UrlFotoEmpleado,Nombre,Apellido,Email,Telefono,Contrasena,RolID,FechaIngreso")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolID"] = new SelectList(_context.Rol, "RolID", "Nombre", empleado.RolID);
            return View(empleado);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return NotFound();

            ViewData["RolID"] = new SelectList(_context.Rol, "RolID", "Nombre", empleado.RolID);
            return View(empleado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpleadoID,UrlFotoEmpleado,Nombre,Apellido,Email,Telefono,Contrasena,RolID,FechaIngreso")] Empleado empleado)
        {
            if (id != empleado.EmpleadoID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Empleados.Any(e => e.EmpleadoID == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolID"] = new SelectList(_context.Rol, "RolID", "Nombre", empleado.RolID);
            return View(empleado);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var empleado = await _context.Empleados
                .Include(e => e.Rol)
                .FirstOrDefaultAsync(m => m.EmpleadoID == id);

            if (empleado == null) return NotFound();

            return View(empleado);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
