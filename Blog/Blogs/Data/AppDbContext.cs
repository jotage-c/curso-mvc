using Blogs.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
