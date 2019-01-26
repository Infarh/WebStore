using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStore.Entities.Entries;
using WebStore.Entities.Identity;

namespace WebStore.DAL
{
    public class WebStoreContext : IdentityDbContext<User>
    {
        public WebStoreContext(DbContextOptions<WebStoreContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Brand> Brands { get; set; }
    }
}
