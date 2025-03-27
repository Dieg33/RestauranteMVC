using Microsoft.AspNetCore.Mvc;

namespace RestauranteMVC.Controllers
{
    public class PlatillosController : Controller
    {
        public IActionResult Crear()
        {
            return View();
        }
    }
}
