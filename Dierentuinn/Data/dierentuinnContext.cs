using Microsoft.EntityFrameworkCore;
using dierentuinn.Models;

namespace dierentuinn.Data
{
    public class DierentuinDbContext : DbContext
    {
        public DierentuinDbContext(DbContextOptions<DierentuinDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dieren> Dierens { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Enclosure> Enclosures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
