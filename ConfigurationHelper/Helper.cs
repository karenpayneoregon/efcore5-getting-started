using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ConfigurationHelper
{
    public class Helper
    {
        private static string _fileName = "appsettings.json";
        /// <summary>
        /// Connection string for application database stored in appsettings.json
        /// Another option would be to have the full connection string in the json file.
        /// </summary>
        /// <returns></returns>
        public static string ConnectionString()
        {

            InitConfiguration();
            var applicationSettings = InitOptions<DatabaseSettings>("database");

            var connectionString =
                $"Data Source={applicationSettings.DatabaseServer};" +
                $"Initial Catalog={applicationSettings.Catalog};" +
                "Integrated Security=True";

            return connectionString;
        }
        /// <summary>
        /// Example for retrieving settings in another section besides the above for database 
        /// </summary>
        /// <returns></returns>
        public static ConfigurationGeneral Configuration()
        {
            InitConfiguration();
            var settings = InitOptions<ConfigurationGeneral>("ConfigurationGeneral");

            return settings;

        }
        /// <summary>
        /// Sample for obtaining a list of <see cref="Keygroup"/> which in itself
        /// is not used for anything, simply an example. 
        /// </summary>
        /// <returns></returns>
        public static List<Keygroup> GetKeyGroups()
        {
            InitConfiguration();
            var settings = InitOptions<List<Keygroup>>("keyGroups");

            return settings;
        }

        /// <summary>
        /// Initialize ConfigurationBuilder
        /// </summary>
        /// <returns>IConfigurationRoot</returns>
        private static IConfigurationRoot InitConfiguration()
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
            var config = InitConfiguration();
            return config.GetSection(section).Get<T>();
        }
    }
}
