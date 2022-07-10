using Microsoft.Extensions.Configuration;
using TFLAutomationChallenge.Configuration.ConfigModels;

namespace TFLAutomationChallenge.Configuration.ConfigHelper
{
    public class AppSettingsHelper
    {
        public static AppConfigSettings GetConfigProperty(string configPath)
        {
            AppConfigSettings appSettings = new AppConfigSettings();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configPath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(appSettings);
            return appSettings;
        }
    }
}
