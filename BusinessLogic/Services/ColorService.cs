using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UI.Data;
using UI.Models;

namespace UI.Controllers
{
    public class ColorService
    {
        ApplicationDbContext _context;
        public ColorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Color> Get(int id)
        {
            var color = await _context.Colors.FindAsync(id);//Read
            return color;
        }

        public async Task<List<Color>> GetAll()
        {
            var colors = await _context.Colors.ToListAsync();//Read
            await _context.Colors.ToListAsync();
            return colors;
        }

        public async Task DeleteColor(int id)
        {
            var phone = await Get(id);
            _context.Colors.Remove(phone);//Delete
            await _context.SaveChangesAsync();
        }

        public async Task AddColor(Color productFromForm)
        {
            await _context.Colors.AddAsync(productFromForm);//Create
            await _context.SaveChangesAsync();
        }

        public async Task EditColor(Color productFromForm)
        {
            _context.Colors.Update(productFromForm);//Update
            await _context.SaveChangesAsync();
        }

    }
}
