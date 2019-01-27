using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebStore.DAL;
using WebStore.Entities.Entries;
using WebStore.Entities.Identity;

namespace WebStore.Data
{
    public class DbInitializer
    {
        public static void Initialize(WebStoreContext context)
        {
            context.Database.EnsureCreated();

            if(context.Products.Any()) return;

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

        public static void InitializeIdentity(WebStoreContext context, IServiceProvider service)
        {
            var roles = new RoleStore<IdentityRole>(context);
            var role_manager = new RoleManager<IdentityRole>(roles,
                new IRoleValidator<IdentityRole>[0],
                new UpperInvariantLookupNormalizer(), 
                new IdentityErrorDescriber(), 
                null);

            const string role_name_user = "User";
            if (!role_manager.RoleExistsAsync(role_name_user).Result)
                role_manager.CreateAsync(new IdentityRole(role_name_user)).Wait();

            const string role_name_admin = "Admin";
            if (!role_manager.RoleExistsAsync(role_name_admin).Result)
                role_manager.CreateAsync(new IdentityRole(role_name_admin)).Wait();

            var users = new UserStore<User>(context);
            var user_manager = new UserManager<User>(users,
                new OptionsManager<IdentityOptions>(
                    new OptionsFactory<IdentityOptions>(
                        new IConfigureOptions<IdentityOptions>[0],
                        new IPostConfigureOptions<IdentityOptions>[0])),
                new PasswordHasher<User>(),
                new IUserValidator<User>[0],
                new IPasswordValidator<User>[0],
                new UpperInvariantLookupNormalizer(), 
                new IdentityErrorDescriber(), 
                null, null);

            const string user_name_admin = "Admin";
            if (users.FindByNameAsync(user_name_admin).Result == null)
            {
                var admin = new User
                {
                    UserName = user_name_admin,
                    Email = $"{user_name_admin.ToLower()}@server.com"
                };
                if (user_manager.CreateAsync(admin, "admin").Result.Succeeded)
                    user_manager.AddToRoleAsync(admin, role_name_admin).Wait();
            }
        }
    }
}
