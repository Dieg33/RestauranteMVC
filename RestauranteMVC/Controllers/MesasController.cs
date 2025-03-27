using Microsoft.AspNetCore.Mvc;

namespace RestauranteMVC.Controllers
{
    public class MesasController : Controller
    {
        public IActionResult Crear()
        {
            return View();
        }
    }
}
