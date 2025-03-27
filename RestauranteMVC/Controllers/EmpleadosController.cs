using Microsoft.AspNetCore.Mvc;

namespace RestauranteMVC.Controllers
{
    public class EmpleadosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
