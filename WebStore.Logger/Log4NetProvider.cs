using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using System.Xml;
using Microsoft.Extensions.Logging;

namespace WebStore.Logger
{
    public class Log4NetProvider : ILoggerProvider
    {
        private readonly string _ConfigurationFile;
        private readonly ConcurrentDictionary<string, Log4NetLogger> _Loggers = new ConcurrentDictionary<string, Log4NetLogger>();

        public Log4NetProvider(string ConfigurationFile) => _ConfigurationFile = ConfigurationFile;

        public ILogger CreateLogger(string category) =>
            _Loggers.GetOrAdd(category, name =>
            {
                var dir = Path.GetDirectoryName(new Uri(Assembly.GetEntryAssembly().CodeBase).AbsolutePath);
                var xml = new XmlDocument();
                xml.Load(Path.Combine(dir, _ConfigurationFile));
                return new Log4NetLogger(name, xml["log4net"]);
            });

        public void Dispose() => _Loggers.Clear();
    }
}
