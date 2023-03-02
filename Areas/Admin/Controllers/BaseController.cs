using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace Project_WAD.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaseController : Controller, IActionFilter
    {
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("AdminLogin") == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { Controller = "Login", Action = "Index", Areas = "Admin" })
                );
            }
            base.OnActionExecuting(context);
        }

    }
}
