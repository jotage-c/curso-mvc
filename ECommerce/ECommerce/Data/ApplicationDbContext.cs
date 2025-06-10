using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //classe model sempre no singular, props como essa aqui no plural (nomenclatura)
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Action",
                    DisplayOrder = 1
                },
                new Category
                {
                    Id = 2,
                    Name = "Adventure",
                    DisplayOrder = 2
                },
                new Category
                {
                    Id = 3,
                    Name = "RPG",
                    DisplayOrder = 3
                }
            );
        }
    }
}
