using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_WAD.Areas.Admin.Models.DataModel;
using Project_WAD.Areas.Admin.Models.BusinessModel;
using System.Linq;

namespace Project_WAD.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet] // GET Hiển thị form để nhập dữ liệu
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] // POST khi submit form
        public IActionResult Index(Login model)
        {

            if (!ModelState.IsValid)
            {
                return View(model); // trả về trạng thái lỗi
            }
            else
            {
                // sẽ xử lý logic phần đăng nhập tại đây
                var checkAccount = _context.Accounts.FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
                if (checkAccount != null)
                {
                    HttpContext.Session.SetString("AdminLogin", model.Email);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản Email hoặc mật khẩu không đúng");
                }

            }

            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminLogin"); // Hủy session với key AdminLogin đã lưu trước đó
            return RedirectToAction("Index");
        }


    }
}
