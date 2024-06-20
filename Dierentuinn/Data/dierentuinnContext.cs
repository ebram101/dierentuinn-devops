using dierentuinn.Models;
using Microsoft.EntityFrameworkCore;

namespace dierentuinn.Data
{
    public class DierentuinDbContext : DbContext
    {
        public DierentuinDbContext(DbContextOptions <DierentuinDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dieren> Dierens { get; set; }
         public DbSet<Category> Categories { get; set; }
         public DbSet<Enclosure> Enclosures { get; set; }
        public DbSet<CustomSize> CustomSizes { get; set; }
    }
}




