using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Data;
using UI.Models;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        PhoneService _productService;
        ColorService _colorService;
        public ProductController(
            PhoneService productService, 
            ColorService colorService)
        {
            _productService = productService;
            _colorService = colorService;
        }

        public async Task<IActionResult> Index()
        {
            var phones = await _productService.GetAll();//Read
            return View(phones);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Phone productFromForm)
        {
            await _productService.AddProduct(productFromForm);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var phone = await _productService.Get(id);//Read
            return View(phone);
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(Phone productFromForm)
        {
            await _productService.EditProduct(productFromForm);//Update
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> AddColor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddColor(Color colorFromForm)
        {
            await _colorService.AddColor(colorFromForm);
            return RedirectToAction("Index");
        }
    }
}
