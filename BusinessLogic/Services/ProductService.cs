using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Data;
using UI.Models;

namespace UI.Controllers
{
    public class ProductService
    {
        ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Phone Get(int id)
        {
            var phone = _context.Phones.Find(id);//Read
            return phone;
        }

        public List<Phone> GetAll()
        {
            var phones = _context.Phones.ToList();//Read
            return phones;
        }

        public void DeleteProduct(int id)
        {
            var phone = Get(id);
            _context.Phones.Remove(phone);//Delete
            _context.SaveChanges();
        }

        public void AddProduct(Phone productFromForm)
        {
            _context.Phones.Add(productFromForm);//Create
            _context.SaveChanges();
        }

        public void EditProduct(Phone productFromForm)
        {
            _context.Phones.Update(productFromForm);//Update
            _context.SaveChanges();
        }

    }
}
