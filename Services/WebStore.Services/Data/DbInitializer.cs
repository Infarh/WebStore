using System;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebStore.DAL.Context;
using WebStore.Entities.Identity;

namespace WebStore.Services.Data
{
    public class DbInitializer
    {
        public static void Initialize(WebStoreContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any()) return;

            using (var transaction = context.Database.BeginTransaction())
            {
                foreach (var section in TestData.Sections) context.Sections.Add(section);

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Sections] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Sections] OFF");

                transaction.Commit();
            }

            using (var transaction = context.Database.BeginTransaction())
            {
                foreach (var brand in TestData.Brands) context.Brands.Add(brand);

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Brands] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Brands] OFF");

                transaction.Commit();
            }

            using (var transaction = context.Database.BeginTransaction())
            {
                foreach (var product in TestData.Products) context.Products.Add(product);

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Products] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Products] OFF");

                transaction.Commit();
            }
        }

        public static void InitializeIdentity(IServiceProvider service)
        {
            var role_manager = service.GetService<RoleManager<IdentityRole>>();

            const string role_name_user = "User";
            if (!role_manager.RoleExistsAsync(role_name_user).Result)
                role_manager.CreateAsync(new IdentityRole(role_name_user)).Wait();

            const string role_name_admin = "Admin";
            if (!role_manager.RoleExistsAsync(role_name_admin).Result)
                role_manager.CreateAsync(new IdentityRole(role_name_admin)).Wait();

            var user_manager = service.GetService<UserManager<User>>();
            var users = service.GetService<IUserStore<User>>();

            const string user_name_admin = "Admin";
            if (users.FindByNameAsync(user_name_admin, CancellationToken.None).Result == null)
            {
                var admin = new User
                {
                    UserName = user_name_admin,
                    Email = $"{user_name_admin.ToLower()}@server.com"
                };

                if (user_manager.CreateAsync(admin, "AdminPassword@123").Result.Succeeded)
                    user_manager.AddToRoleAsync(admin, role_name_admin).Wait();
            }
        }
    }
}
