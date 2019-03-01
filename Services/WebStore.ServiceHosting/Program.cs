using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebStore.DAL.Context;
using WebStore.Services.Data;

namespace WebStore.ServiceHosting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<WebStoreContext>();
                    DbInitializer.Initialize(context);
                    DbInitializer.InitializeIdentity(services);
                }
                catch (Exception e)
                {
                    services.GetRequiredService<ILogger<Program>>().LogError(e, "Ошибка инициализации базы данных");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
