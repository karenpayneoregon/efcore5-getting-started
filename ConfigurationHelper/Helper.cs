﻿using System.IO;
using Microsoft.Extensions.Configuration;

namespace ConfigurationHelper
{
    public class Helper
    {
        /// <summary>
        /// Connection string for application database stored in appsettings.json
        /// </summary>
        /// <returns></returns>
        public static string ConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            var applicationSettings = config.GetSection("database").Get<ApplicationSettings>();

            var connectionString =
                $"Data Source={applicationSettings.DatabaseServer};" +
                $"Initial Catalog={applicationSettings.Catalog};" +
                "Integrated Security=True";

            return connectionString;
        }
    }
}
