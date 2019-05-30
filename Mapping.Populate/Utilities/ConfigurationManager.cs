using Mapping.Populate.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Mapping.Populate.Utilities
{
    internal static class ConfigurationManager
    {
        public static Configuration GetConfiguration() => ConfigurationBinder.Get<Configuration>(
                new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build()
            );
    }
}