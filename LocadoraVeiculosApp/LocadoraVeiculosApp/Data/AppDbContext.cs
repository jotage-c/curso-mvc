using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculosApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Rent> Rents { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>().Property(v => v.ValorDiaria).HasPrecision(10, 2);
            modelBuilder.Entity<Rent>().Property(l => l.ValorTotal).HasPrecision(10, 2);
            modelBuilder.Entity<Rent>().Property(l => l.ValorMulta).HasPrecision(10, 2);
        }
    }
}
