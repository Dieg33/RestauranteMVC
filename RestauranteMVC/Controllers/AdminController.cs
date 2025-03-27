using Microsoft.AspNetCore.Mvc;

namespace RestauranteMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
