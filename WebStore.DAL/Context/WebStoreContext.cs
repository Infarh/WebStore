using Microsoft.EntityFrameworkCore;
using WebStore.Entities.Entries;

namespace WebStore.DAL
{
    public class WebStoreContext : DbContext
    {
        public WebStoreContext(DbContextOptions<WebStoreContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Brand> Brands { get; set; }
    }
}
