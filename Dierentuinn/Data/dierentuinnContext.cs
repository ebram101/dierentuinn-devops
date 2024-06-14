using Microsoft.EntityFrameworkCore;
using dierentuinn.Models;

namespace dierentuinn.Data
{
    public class DierentuinnContext : DbContext
    {
        public DierentuinnContext(DbContextOptions<DierentuinnContext> options)
            : base(options)
        {
        }

        public DbSet<Dieren> Dierens { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Enclosure> Enclosures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dieren>()
                .HasOne(d => d.Category)
                .WithMany(c => c.Dierens)
                .HasForeignKey(d => d.CategoryId);

            modelBuilder.Entity<Dieren>()
                .HasOne(d => d.Enclosure)
                .WithMany(e => e.Dierens)
                .HasForeignKey(d => d.EnclosureId);

            modelBuilder.Entity<CustomSize>()
              .HasKey(c => c.CustomSizeId);
        }
    }
}
