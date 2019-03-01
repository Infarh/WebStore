using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace WebStore.Logger
{
    public static class Log4NetConfigurationExtensions
    {
        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string ConfigurationFile = "log4net.config")
        {
            factory.AddProvider(new Log4NetProvider(ConfigurationFile));
            return factory;
        }
    }
}
