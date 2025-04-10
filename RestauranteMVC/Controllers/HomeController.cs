using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RestauranteMVC.Models;
using RestauranteMVC.Servicios;

namespace RestauranteMVC.Controllers;

public class HomeController(ILogger<HomeController> logger, RestauranteDbContext context) : Controller
{
    private readonly RestauranteDbContext _context = context;
    private readonly ILogger<HomeController> _logger = logger;

    [Autenticacion]
    public IActionResult Index()
    {
        var EmpleadoID = HttpContext.Session.GetInt32("EmpleadoID");
        var Nombre = HttpContext.Session.GetString("Nombre");

        if (EmpleadoID == null)
        {
            return RedirectToAction("Autenticar");
        }

        ViewBag.nombre = Nombre;
        ViewData["Apellido"] = Nombre;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Autenticar(string txtEmail, string txtClave)
    {
        var empleado = (from e in _context.Empleados
                        where e.Email == txtEmail && e.Contrasena == txtClave && e.RolID != 0
                        select e).FirstOrDefault();

        if (empleado != null)
        {
            HttpContext.Session.SetInt32("EmpleadoID", empleado.EmpleadoID); // corregido
            HttpContext.Session.SetString("RolID", empleado.RolID.ToString());
            HttpContext.Session.SetString("Nombre", empleado.Nombre ?? ""); // protegido contra null

            return RedirectToAction("Index", "Admin");
        }

        ViewData["ErrorMessage"] = "Error, empleado inválido!";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Autenticar()
    {
        ViewData["ErrorMessage"] = "";
        return View();
    }
}
