using System;
using System.IO;
using System.Reflection;
using System.Xml;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebStore.Clients.Services;
using WebStore.Clients.Services.Employees;
using WebStore.Clients.Services.Orders;
using WebStore.Clients.Services.Products;
using WebStore.Clients.Services.Users;
using WebStore.Entities.Identity;
using WebStore.Interfaces.Api;
using WebStore.Interfaces.Services;
using WebStore.Services;

namespace WebStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;

            var xml = new XmlDocument();
            xml.Load(Path.Combine(env.ContentRootPath, "log4net.config"));

            var repository = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            var result = log4net.Config.XmlConfigurator.Configure(repository, xml["log4net"]);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IEmployeesData, EmployeesClient>();
            services.AddTransient<IProductData, ProductsClient>();
            services.AddScoped<ICartService, CookieCartService>();
            services.AddTransient<IOrderService, OrdersClient>();
            services.AddTransient<IValuesService, ValuesClient>();

            services.AddTransient<IUsersClient, UsersClient>();

            services.AddIdentity<User, IdentityRole>()
                .AddDefaultTokenProviders();

            #region Custom identity

            services.AddTransient<IUserStore<User>, UsersClient>();
            services.AddTransient<IUserRoleStore<User>, UsersClient>();
            services.AddTransient<IUserClaimStore<User>, UsersClient>();
            services.AddTransient<IUserPasswordStore<User>, UsersClient>();
            services.AddTransient<IUserTwoFactorStore<User>, UsersClient>();
            services.AddTransient<IUserEmailStore<User>, UsersClient>();
            services.AddTransient<IUserPhoneNumberStore<User>, UsersClient>();
            services.AddTransient<IUserLoginStore<User>, UsersClient>();
            services.AddTransient<IUserLockoutStore<User>, UsersClient>();
            services.AddTransient<IRoleStore<IdentityRole>, RolesClient>();

            #endregion

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;
                //options.Password.RequireDigit = true;
                //options.Password.RequireLowercase = true;
                //options.Password.RequireNonAlphanumeric = true;
                //options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 4;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                //options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AcessDenied";
                options.SlidingExpiration = true;
            });

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
