using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Data;
using UI.Models;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var phones = _productService.GetAll();//Read
            return View(phones);
        }

        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
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
            _productService.AddProduct(productFromForm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var phone = _productService.Get(id);//Read
            return View(phone);
        }
        [HttpPost]
        public IActionResult EditProduct(Phone productFromForm)
        {
            _productService.EditProduct(productFromForm);//Update
            return RedirectToAction("Index");
        }

    }
}
