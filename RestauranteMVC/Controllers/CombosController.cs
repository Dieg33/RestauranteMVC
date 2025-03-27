using Microsoft.AspNetCore.Mvc;

namespace RestauranteMVC.Controllers
{
    public class CombosController : Controller
    {
        public IActionResult Crear()
        {
            return View();
        }
    }
}
