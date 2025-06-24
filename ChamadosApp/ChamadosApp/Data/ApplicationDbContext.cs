using ChamadosApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChamdosApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //classe model sempre no singular, props como essa aqui no plural (nomenclatura)
        public DbSet<Call> Calls { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
