using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UI.Models;

namespace UI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Color> Colors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var phones = new Phone[3];
            phones[0] = new Phone();
            phones[1] = new Phone();
            phones[2] = new Phone();

            phones[0].Id = 1;
            phones[1].Id = 2;
            phones[2].Id = 3;

            phones[0].Model = "9";
            phones[1].Model = "10";
            phones[2].Model = "11";

            phones[0].Price = 80;
            phones[1].Price = 90;
            phones[2].Price = 100;

            phones[0].Description = "Poor phone";
            phones[1].Description = "Norm phone";
            phones[2].Description = "Cool phone";

            phones[0].ColorId = 1;
            phones[1].ColorId = 1;
            phones[2].ColorId = 1;

            builder.Entity<Phone>().HasData(phones);


            var colors = new Color[2];
            colors[0] = new Color();
            colors[1] = new Color();

            colors[0].Id = 1;
            colors[1].Id = 2;

            colors[0].Name = "Red";
            colors[1].Name = "Green";

            builder.Entity<Color>().HasData(colors);
        }
    }
}
