using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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
        /// Log options
        /// </summary>
        /// <returns></returns>
        public static LoggingDistination LoggingDistination()
        {
            InitConfiguration();

            var applicationSettings = InitOptions<DatabaseSettings>("database");
            return applicationSettings.LoggingDistination;
        }
        /// <summary>
        /// Log file name
        /// </summary>
        /// <returns></returns>
        public static string LogFileName()
        {
            InitConfiguration();

            var applicationSettings = InitOptions<DatabaseSettings>("database");
            return applicationSettings.LogFileName;
            
        }
        public static bool UseLogging()
        {
            InitConfiguration();
            var applicationSettings = InitOptions<ApplicationSettings>("database");

            return applicationSettings.UsingLogging;

        }

        /// <summary>
        /// Combination of settings
        /// </summary>
        /// <returns></returns>
        public static GeneralSettings Configuration()
        {
            InitConfiguration();
            
            return InitOptions<GeneralSettings>("GeneralSettings");
        }
        /// <summary>
        /// Update email settings
        /// </summary>
        /// <param name="emailSettings">New settings</param>
        public static void UpdateEmail(EmailSettings emailSettings)
        {
            var generalSettings = Configuration();

            generalSettings.EmailSettings.Host = emailSettings.Host;
            generalSettings.EmailSettings.Port = emailSettings.Port;
            generalSettings.EmailSettings.DefaultCredentials = emailSettings.DefaultCredentials;
            generalSettings.EmailSettings.EnableSsl = emailSettings.EnableSsl;
            generalSettings.EmailSettings.PickupDirectoryLocation = emailSettings.PickupDirectoryLocation;


            string output = JsonConvert.SerializeObject(generalSettings, Formatting.Indented);
            File.WriteAllText(_fileName, output);
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
