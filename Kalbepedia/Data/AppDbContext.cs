using Microsoft.EntityFrameworkCore;
using Kalbepedia.Models; // adjust to match your namespace

namespace Kalbepedia.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Kalbepedia.Models.Product> Products { get; set; }
        public DbSet<Kalbepedia.Models.ProductCategory> Product_Categories { get; set; }
        public DbSet<Kalbepedia.Models.Cart> Carts { get; set; }
        public DbSet<Kalbepedia.Models.User> Users { get; set; }
    }
}
