
using System;
using System.IO;
using System.Linq;
using ConnectionStandard.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ConnectionStandard.Models;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace ConnectionStandard.Contexts
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(BuildConnection());
            }
        }
        /// <summary>
        /// Build connection string from appsettings.json in section database
        /// </summary>
        /// <returns>Connection string</returns>
        private static string BuildConnection()
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var sections = configuration.GetSection("database").GetChildren().ToList();

            var connectionString =
                $"Data Source={sections[1].Value};" +
                $"Initial Catalog={sections[0].Value};" +
                $"Integrated Security={sections[2].Value}";

            
            return connectionString;
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

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}