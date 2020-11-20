using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ConfigurationHelper
{
    public class Helper
    {
        private static string _fileName = "appsettings.json";
        /// <summary>
        /// Connection string for application database stored in appsettings.json
        /// </summary>
        /// <returns></returns>
        public static string ConnectionString()
        {

            var config = InitConfig();

            var applicationSettings = config.GetSection("database").Get<DatabaseSettings>();

            var connectionString =
                $"Data Source={applicationSettings.DatabaseServer};" +
                $"Initial Catalog={applicationSettings.Catalog};" +
                "Integrated Security=True";

            return connectionString;
        }
        /// <summary>
        /// Initialize ConfigurationBuilder
        /// </summary>
        /// <returns>IConfigurationRoot</returns>
        private static IConfigurationRoot InitConfig()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(_fileName);

            return builder.Build();

        }
        /// <summary>
        /// Generic method to read a section from the json configuration file.
        /// </summary>
        /// <typeparam name="T">Class type</typeparam>
        /// <param name="section">Section to read</param>
        /// <returns>Instance of T</returns>
        public static T InitOptions<T>(string section) where T : new()
        {
            var config = InitConfig();
            return config.GetSection(section).Get<T>();
        }
    }
}
