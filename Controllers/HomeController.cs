using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_WAD.Areas.Admin.Models.BusinessModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var topProduct = _context.Products.OrderByDescending(p => p.Id).Take(6);
            var category = _context.Categories.ToList();
            ViewBag.TopProduct = topProduct;
            ViewBag.Category = category;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Blog()
        {
            var blog = _context.Blogs.ToList();
            ViewBag.Blog = blog;

            return View();
        }

        public IActionResult Blog_Detail()
        {
            ViewData["Message"] = "Your blog page.";

            return View();
        }

        public IActionResult Product(int cateId)
        {
            var product = _context.Products.OrderByDescending(p => p.Id).Include(p => p.Category).Take(6);
            var category = _context.Categories.ToList();
            var blog = _context.Blogs.ToList();
            if (cateId != 0)
            {
                product = _context.Products.Where(p => p.CategoryId.Equals(cateId)).OrderByDescending(p => p.Id).Include(p => p.Category).Take(6);
            }
            ViewBag.Product = product;
            ViewBag.Category = category;
            ViewBag.Blog = blog;

            return View();
        }

        public IActionResult Product_Detail(int proId)
        {
            var proDetail = _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == proId);
            ViewBag.Pro = proDetail;
            return View(proDetail);
        }

        public IActionResult CheckOut()
        {
            ViewData["Message"] = "Your product page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
