using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace WebStore.Logger
{
    public class Log4NetConfigurationProvider : ConfigurationProvider
    {
        private readonly Log4NetConfigurationSource _ConfigurationSource;
        private readonly IFileProvider _FileProvider;

        public Log4NetConfigurationProvider(Log4NetConfigurationSource ConfigurationSource, IFileProvider FileProvider)
        {
            _ConfigurationSource = ConfigurationSource;
            _FileProvider = FileProvider;
        }

        #region Overrides of ConfigurationProvider

        public override void Load()
        {
            base.Load();
        }

        #endregion
    }
}
