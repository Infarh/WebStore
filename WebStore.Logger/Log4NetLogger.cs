using System;
using System.Reflection;
using System.Xml;
using log4net;
using log4net.Repository;
using Microsoft.Extensions.Logging;

namespace WebStore.Logger
{
    public class Log4NetLogger : ILogger
    {
        private readonly string _Name;

        private readonly XmlElement _XmlElement;

        private readonly ILog _Log;

        private readonly ILoggerRepository _LoggerRepository;

        public Log4NetLogger(string Name, XmlElement xml)
        {
            _Name = Name;
            _XmlElement = xml;
            _LoggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            _Log = LogManager.GetLogger(_LoggerRepository.Name, Name);
            log4net.Config.XmlConfigurator.Configure(_LoggerRepository, xml["log4net"]);
        }

        #region Implementation of ILogger

        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                    return _Log.IsDebugEnabled;
                case LogLevel.Information:
                    return _Log.IsInfoEnabled;
                case LogLevel.Warning:
                    return _Log.IsWarnEnabled;
                case LogLevel.Error:
                    return _Log.IsErrorEnabled;
                case LogLevel.Critical:
                    return _Log.IsFatalEnabled;
                case LogLevel.None:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }

        public void Log<TState>(LogLevel level, EventId id, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(level)) return;
            if (formatter is null) throw new ArgumentNullException(nameof(formatter));

            var msg = formatter(state, exception);
            if(string.IsNullOrEmpty(msg) && exception is null) return;

            switch (level)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                    _Log.Debug(msg);
                    break;
                case LogLevel.Information:
                    _Log.Info(msg);
                    break;
                case LogLevel.Warning:
                    _Log.Warn(msg);
                    break;
                case LogLevel.Error:
                    _Log.Error(msg);
                    break;
                case LogLevel.Critical:
                    _Log.Fatal(msg);
                    break;
                case LogLevel.None:
                    break;
                default:
                    _Log.Warn($"Неизвестный тип уровня логирования {level}");
                    _Log.Info(msg, exception);
                    break;
            }
        }

        #endregion
    }
}
