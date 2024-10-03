using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UI.Models;

namespace UI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Phone> Phones { get; set; }

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

            phones[0].Name = "IPhone 7";
            phones[1].Name = "IPhone 8";
            phones[2].Name = "IPhone 9";

            phones[0].Description = "poor phone";
            phones[1].Description = "norm phone";
            phones[2].Description = "cool phone";

            builder.Entity<Phone>().HasData(phones);
        }
    }
}
