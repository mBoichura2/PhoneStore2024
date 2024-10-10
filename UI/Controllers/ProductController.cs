using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Data;
using UI.Models;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var phones = _context.Phones.ToList();//Read
            return View(phones);
        }

        public IActionResult DeleteProduct(int id)
        {
            var phone = _context.Phones.Find(id);
            _context.Phones.Remove(phone);//Delete
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Phone productFromForm)
        {
            _context.Phones.Add(productFromForm);//Create
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var phone = _context.Phones.Find(id);//Read
            return View(phone);
        }
        [HttpPost]
        public IActionResult EditProduct(Phone productFromForm)
        {
            _context.Phones.Update(productFromForm);//Update
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
