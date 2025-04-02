using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RestauranteMVC.Servicios
{
    public class AutenticacionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session.GetInt32("EmpleadoID");
            if (session == null)
            {
                context.Result = new RedirectToActionResult("Autenticar", "Home", null);
            }
            base.OnActionExecuting(context);
        }

    }
}
