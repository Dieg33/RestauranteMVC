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

    // POST: Autenticar usando un modelo Empleado
    [HttpPost]
    public IActionResult Autenticar(Empleado modelo)
    {
        var empleado = _context.Empleados
            .FirstOrDefault(e => e.Email == modelo.Email && e.Contrasena == modelo.Contrasena && e.RolID != 0);

        if (empleado != null)
        {
            HttpContext.Session.SetInt32("EmpleadoID", empleado.EmpleadoID);
            HttpContext.Session.SetString("RolID", empleado.RolID.ToString());
            HttpContext.Session.SetString("Nombre", empleado.Nombre ?? "");

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
