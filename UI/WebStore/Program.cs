using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using log4net;
using log4net.Appender;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebStore.DAL;
using WebStore.DAL.Context;
using WebStore.Logger;
using WebStore.Services.Data;

namespace WebStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            LogManager.GetLogger(typeof(Program)).Info("Application - Main is invoked");
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((host, log) => log.AddLog4Net()) // https://docs.microsoft.com/ru-ru/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2
                .UseStartup<Startup>();
    }
}
