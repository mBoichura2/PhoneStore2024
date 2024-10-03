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
            var phones = _context.Phones.ToList();
            return View(phones);
        }

        public IActionResult AddPhone()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPhone(Phone phone)
        {
            _context.Phones.Add(phone);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
