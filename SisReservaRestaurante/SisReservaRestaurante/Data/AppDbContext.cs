using Microsoft.EntityFrameworkCore;
using SisReservaRestaurante.Models;

namespace SisReservaRestaurante.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mesa>().HasData(
                new Mesa
                {
                    Id = 1,
                    Lugares = 2
                },
                new Mesa
                {
                    Id = 2,
                    Lugares = 4
                },
                new Mesa
                {
                    Id = 3,
                    Lugares = 4
                }
            );
        }
    }
}
