using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dierentuinn.Models;

namespace dierentuinn.Data
{
    public class dierentuinnContext : DbContext
    {
        public dierentuinnContext (DbContextOptions<dierentuinnContext> options)
            : base(options)
        {
        }

        public DbSet<dierentuinn.Models.Dieren> Dieren { get; set; } = default!;
    }
}
