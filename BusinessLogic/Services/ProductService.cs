using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Phone> Get(int id)
        {
            var phone = await _context.Phones.FindAsync(id);//Read
            return phone;
        }

        public async Task<List<Phone>> GetAll()
        {
            var phones = await _context.Phones.ToListAsync();//Read
            return phones;
        }

        public async Task DeleteProduct(int id)
        {
            var phone = await Get(id);
            _context.Phones.Remove(phone);//Delete
            await _context.SaveChangesAsync();
        }

        public async Task AddProduct(Phone productFromForm)
        {
            await _context.Phones.AddAsync(productFromForm);//Create
            await _context.SaveChangesAsync();
        }

        public async Task EditProduct(Phone productFromForm)
        {
            _context.Phones.Update(productFromForm);//Update
            await _context.SaveChangesAsync();
        }

    }
}
