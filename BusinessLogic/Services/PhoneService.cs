using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UI.Data;
using UI.Models;

namespace UI.Controllers
{
    public class PhoneService
    {
        Repository<Phone> _productRepo;
        Repository<Color> _colorRepo;
        public PhoneService(
            Repository<Phone> productRepo, 
            Repository<Color> colorRepo)
        {
            _productRepo = productRepo;
            _colorRepo = colorRepo;
        }

        public async Task<Phone> Get(int id)
        {
            var phone = await _productRepo.GetByID(id);//Read
            return phone;
        }

        public async Task<List<Phone>> GetAll()
        {
            var phones = await _productRepo.Get();//Read
            await _colorRepo.Get();
            return phones.ToList();
        }

        public async Task DeleteProduct(int id)
        {
            var phone = await Get(id);
            await _productRepo.Delete(phone);//Delete
            await _productRepo.Save();
        }

        public async Task AddProduct(Phone productFromForm)
        {
            await _productRepo.Insert(productFromForm);//Create
            await _productRepo.Save();
        }

        public async Task EditProduct(Phone productFromForm)
        {
            await _productRepo.Update(productFromForm);//Update
            await _productRepo.Save();
        }

    }
}
