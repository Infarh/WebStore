using Microsoft.Extensions.Configuration;

namespace WebStore.Logger
{
    public class Log4NetConfigurationSource : IConfigurationSource
    {
        public string ConfigurationFile { get; set; }

        public Log4NetConfigurationSource(string ConfigurationFile) => this.ConfigurationFile = ConfigurationFile;

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new Log4NetConfigurationProvider(this, builder.GetFileProvider());
        }
    }
}