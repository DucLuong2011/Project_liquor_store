using Microsoft.AspNetCore.Mvc;

namespace Project_WAD.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
