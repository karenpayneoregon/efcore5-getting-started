using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ConnectionStandard.Contexts
{
    public class ContextFactory : IDesignTimeDbContextFactory<SchoolContext>
    {
        private static string _connectionString;
        private const string FileName = "appsettings.json"; 
        private static bool _isProduction;
        /// <summary>
        /// Creates a SchoolContext for production or development environment
        /// </summary>
        /// <param name="production">true to use production, false or pass nothing for development environment</param>
        /// <returns>Ready to use SchoolContext</returns>
        public static SchoolContext CreateDbContext(bool production = false)
        {
            _isProduction = production;

            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                if (production)
                {
                    LoadProductionConnectionString();
                }
                else
                {
                    LoadDevelopmentConnectionString();
                }

            }

            var builder = new DbContextOptionsBuilder<SchoolContext>();
            // ReSharper disable once AssignNullToNotNullAttribute
            builder.UseSqlServer(_connectionString);

            return new SchoolContext(builder.Options);

        }

        public static SchoolContext CreateDbContext(string[] args)
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                if (_isProduction)
                {
                    LoadProductionConnectionString();
                }
                else
                {
                    LoadDevelopmentConnectionString();
                }
                
            }

            var builder = new DbContextOptionsBuilder<SchoolContext>();
            // ReSharper disable once AssignNullToNotNullAttribute
            builder.UseSqlServer(_connectionString);

            return new SchoolContext(builder.Options);
        }

        private static void LoadDevelopmentConnectionString()
        {
            _connectionString = ConfigurationBuilderRoot().GetConnectionString("DevelopmentConnection");
        }
        private static void LoadProductionConnectionString()
        {
            _connectionString = ConfigurationBuilderRoot().GetConnectionString("ProductionConnection");
        }
        private static IConfigurationRoot ConfigurationBuilderRoot()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(FileName, optional: false);

            var configuration = builder.Build();
            return configuration;
        }

        SchoolContext IDesignTimeDbContextFactory<SchoolContext>.CreateDbContext(string[] args) => CreateDbContext(args);
    }
}
