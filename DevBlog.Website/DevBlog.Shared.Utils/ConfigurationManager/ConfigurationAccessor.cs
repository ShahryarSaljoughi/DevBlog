using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace DevBlog.Shared.Utils.ConfigurationManager
{
    public static class ConfigurationAccessor
    {
        private static IConfiguration configuration;
        public static IConfiguration AppConfig => configuration ?? InitializeConfiguration();

        private static IConfiguration InitializeConfiguration()
        {
            var isDebuggerAttached = System.Diagnostics.Debugger.IsAttached;
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configuration = configurationBuilder
                .AddJsonFile(
                    isDebuggerAttached ? "appsettings.json" : "appsettings.Production.json", 
                    optional: true, 
                    reloadOnChange: true)
                .Build();
            return configuration;
        }
    }
}
