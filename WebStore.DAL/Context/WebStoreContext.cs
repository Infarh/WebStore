using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStore.Entities.Entries;
using WebStore.Entities.Identity;

namespace WebStore.DAL.Context
{
    public class WebStoreContext : IdentityDbContext<User>
    {
        public WebStoreContext(DbContextOptions<WebStoreContext> options) : base(options) { }

        /// <summary>Товары</summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>Разделы</summary>
        public DbSet<Section> Sections { get; set; }

        /// <summary>Бренды</summary>
        public DbSet<Brand> Brands { get; set; }

        /// <summary>Заказы</summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>Элементы заказов</summary>
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
