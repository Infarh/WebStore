using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebStore.Logger
{
    public static class Log4NetConfigurationExtensions
    {
        public static IConfigurationBuilder AddLog4NetConfiguration(this IConfigurationBuilder builder, string FileName = "log4net.config") =>
            builder.Add(new Log4NetConfigurationSource(FileName));

        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string ConfigurationFile = "log4net.config")
        {
            factory.AddProvider(new Log4NetProvider(ConfigurationFile));
            return factory;
        }

        public static ILoggingBuilder AddLog4NetLogger(this ILoggingBuilder builder, string ConfigurationFile = "log4net.config")
        {
            try
            {
                var hosting = (IHostingEnvironment)builder.Services.First(s => s.ServiceType == typeof(IHostingEnvironment)).ImplementationInstance;
                var base_directory = hosting.ContentRootPath;

                var configuration_file_path = Path.Combine(base_directory, ConfigurationFile);

                builder.AddProvider(new Log4NetProvider(configuration_file_path));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return builder;
        }
    }
}
