
using System;
using System.IO;
using System.Linq;
using ConnectionStandard.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ConnectionStandard.Models;
using Microsoft.Extensions.Configuration;
using Environment = ConnectionStandard.Classes.Environment;

#nullable disable

namespace ConnectionStandard.Contexts
{
    public partial class SchoolContext1 : DbContext
    {
        /// <summary>
        /// Connection string to interact with the database
        /// </summary>
        private static string _connectionString;
        /// <summary>
        /// Configuration file
        /// </summary>
        private static string _fileName = "appsettings.json";

        /// <summary>
        /// Setup connection string
        /// </summary>
        public SchoolContext1()
        {
            GetConnectionString();
            GetSettings();
        }

        public SchoolContext1(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EnrollmentDate)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HireDate)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        #region Connection string based on environment

        /// <summary>
        /// Get connection string based on environment
        /// </summary>
        private static void GetConnectionString()
        {
            _connectionString = ConfigurationBuilderRoot()
                .GetConnectionString(InitOptions<Environment>("Environment").Production ?
                "ProductionConnection" :
                "DevelopmentConnection");
        }

        public ConnectionStrings GetSettings()
        {
            var result = new ConnectionStrings();
            try
            {
                InitConfiguration();
                var connectionStrings = InitOptions<ConnectionStrings>("ConnectionStrings");
                var environment = InitOptions<Environment>("Environment");

                return new ConnectionStrings()
                {
                    DevelopmentConnection = connectionStrings.DevelopmentConnection,
                    ProductionConnection = connectionStrings.ProductionConnection, 
                    IsProduction = environment.Production
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public static T InitOptions<T>(string section) where T : new()
        {
            return InitConfiguration().GetSection(section).Get<T>();
        }
        private static IConfigurationRoot InitConfiguration()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(_fileName);

            return builder.Build();

        }
        private static IConfigurationRoot ConfigurationBuilderRoot()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(_fileName, optional: false);

            var configuration = builder.Build();
            return configuration;
        }

        #endregion

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}