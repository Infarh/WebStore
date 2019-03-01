using System;
using log4net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebStore.DAL;
using WebStore.DAL.Context;
using WebStore.Services.Data;

namespace WebStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var str = Environment.CurrentDirectory;

            var host = CreateWebHostBuilder(args).Build();
            LogManager.GetLogger(typeof(Program)).Info("Application - Main is invoked");
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
