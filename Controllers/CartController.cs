using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Project_WAD.Areas.Admin.Models.BusinessModel;
using Project_WAD.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project_WAD.Controllers
{
    public class CartController : Controller, IActionFilter
    {
        private readonly AppDbContext _context;
        private List<Cart> carts = new List<Cart>();
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var cartInSession = HttpContext.Session.GetString("My-Carrt"); // Dữ liệu lưu trong sesion
            if (cartInSession != null)
            {
                // nếu sesion không null, gán dữ liệu cho biến carts
                // chuyên đổi chuỗi json => đối tượng List<Cart> phù hợp
                carts = JsonConvert.DeserializeObject<List<Cart>>(cartInSession);
            }
            base.OnActionExecuting(context);
        }

        public CartController(AppDbContext context)
        {
            _context = context; // sử dụng khi cần truy vân dữ liệu
        }

        public IActionResult Add(int id)
        {
            
            if (carts.Any(c => c.Id == id)) // nếu đã có sản phẩm này tron Session giỏ hàng
            {
                carts.Where(c => c.Id == id).First().Quantity += 1; // tìm và tăn số lượng lên
            }
            else
            {
                
                // nếu chưa có trong sesion giỏ hàng
                var pro = _context.Products.Find(id); // truy vấn lấy thông tin sản phẩm trong CSDL theo id

                // khởi tao đối tượng từ model Cart và gán thông tin cho các thuộc tính
                var Item = new Cart() { Id = pro.Id, Name = pro.Name, Price = pro.Price, Image = pro.Image, Quantity = 1,Total=1*pro.Price};
                
                carts.Add(Item); // thêm vào List<Cart> đã khai báo ở trên
            }

            // lưu vào Session, cần phải chyển đổi List<Cart> => chuỗi json
            HttpContext.Session.SetString("My-Carrt", JsonConvert.SerializeObject(carts));

            return RedirectToAction("Index", "Cart"); // chuyển hướng về index, nhớ tạo view cho action Index

        } // thực hiện lưu xử lý logic cho phần thêm mới giỏ hàng
        public IActionResult Remove(int id)
        {
            if (carts.Any(c => c.Id == id)) // nếu có sản phẩm này tron Session giỏ hàng
            {
                var item = carts.Where(c => c.Id == id).First(); // tìm sản phẩm đó trong session giỏ hàng
                carts.Remove(item); // Xóa đối trượng Cart tìm được khỏi List<Cart>
                // lưu lại Session, cần phải chyển đổi List<Cart> => chuỗi json
                HttpContext.Session.SetString("My-Carrt", JsonConvert.SerializeObject(carts));
            }
            return RedirectToAction("Index", "Cart");
        } // Xóa sản phẩm ra khỏi sesion

        public IActionResult Update(int id, int quantity,float price)
        {
            if (carts.Any(c => c.Id == id)) // nếu có sản phẩm này tron Session giỏ hàng
            {
                carts.Where(c => c.Id == id).First().Quantity = quantity; // gán lại số lượng đã truyền vào
                // lưu lại Session, cần phải chyển đổi List<Cart> => chuỗi json
                HttpContext.Session.SetString("My-Carrt", JsonConvert.SerializeObject(carts));
            }
            if (carts.Any(c => c.Id == id)) // nếu có sản phẩm này tron Session giỏ hàng
            {
                carts.Where(c => c.Id == id).First().Total = quantity*price; // gán lại tổng tiền đã truyền vào
                // lưu lại Session, cần phải chyển đổi List<Cart> => chuỗi json
                HttpContext.Session.SetString("My-Carrt", JsonConvert.SerializeObject(carts));
            }
            return RedirectToAction("Index", "Cart");
        } // cập nhật sô lượng

        public IActionResult Clear()
        {
            // lưu lại Session, chỉ cần List<Cart> => null
            HttpContext.Session.Remove("My-Carrt");
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Index()
        {
            return View(carts);
        } // Hiển thị danh sách sản phẩm trong giỏ hàng

    }
}
