using ExercicioManipulacaoDb.Models;
using Microsoft.EntityFrameworkCore;

namespace ExercicioManipulacaoDb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, Name = "NieR: Replicant", Price = 249.90, LaunchingYear = "2022" },
                new Game { Id = 2, Name = "The Elder Scrolls IV: Oblivion Remastered", Price = 264.90, LaunchingYear = "2025" },
                new Game { Id = 3, Name = "Elden Ring", Price = 274.50, LaunchingYear = "2021" }
                );

            modelBuilder.Entity<Song>().HasData(
                new Song { Id = 1, Name = "Liebestraume no. 3", Author = "Franz Liszt", Genre = "Classical" },
                new Song { Id = 2, Name = "Tea For Two", Author = "Ella Fitzgerald", Genre = "Jazz" },
                new Song { Id = 3, Name = "Madrugada", Author = "Fat Family", Genre = "R&B" }
                );
        }
    }
}
