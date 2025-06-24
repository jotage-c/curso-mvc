using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using docasp.Models;

namespace docasp.Data
{
    public class docaspContext : DbContext
    {
        public docaspContext (DbContextOptions<docaspContext> options)
            : base(options)
        {
        }

        public DbSet<docasp.Models.Movie> Movie { get; set; } = default!;
    }
}
