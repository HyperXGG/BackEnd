using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WineShopApplication.Data
{
    public class AlcoholManagementDbContext : IdentityDbContext<IdentityUser>
    {
        public AlcoholManagementDbContext(DbContextOptions<AlcoholManagementDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
    }
}
