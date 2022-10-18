using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NerdStore.Models;

namespace NerdStore.Data
{
    public class NerdStoreContext : DbContext
    {
        public NerdStoreContext (DbContextOptions<NerdStoreContext> options)
            : base(options)
        {
        }

        public DbSet<NerdStore.Models.Product> Product { get; set; }
        public DbSet<NerdStore.Models.Department> Department { get; set; }
        public DbSet<NerdStore.Models.SalesRecord> SalesRecord { get; set; }
        public DbSet<NerdStore.Models.Seller> Seller { get; set; }

    }
}
