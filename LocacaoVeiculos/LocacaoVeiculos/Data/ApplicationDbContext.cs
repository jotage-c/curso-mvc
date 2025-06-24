using LocacaoVeiculos.Models;
using Microsoft.EntityFrameworkCore;

namespace LocacaoVeiculos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
