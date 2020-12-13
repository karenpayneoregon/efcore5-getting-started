﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using ConfigurationHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using NorthEntityLibrary.Classes;
using NorthEntityLibrary.Models;

namespace NorthEntityLibrary.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// See the following for logging
    /// https://docs.microsoft.com/en-us/ef/core/logging-events-diagnostics/simple-logging#logging-to-a-file
    /// </remarks>
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BusinessEntityPhone> BusinessEntityPhone { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<ContactDevices> ContactDevices { get; set; }
        public virtual DbSet<ContactType> ContactType { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PhoneType> PhoneType { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }

        /// <summary>
        /// For logging to file via .LogTo
        /// </summary>
        private readonly StreamWriter _logStream = new StreamWriter("ef-log.txt", append: true);
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                if (Helper.UseLogging())
                {
                    optionsBuilder.UseSqlServer(Helper.ConnectionString())
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors()
                        .LogTo(_logStream.WriteLine);
                }
                else
                {
                    optionsBuilder.UseSqlServer(Helper.ConnectionString());
                }

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BusinessEntityPhoneConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new ContactDevicesConfiguration());
            modelBuilder.ApplyConfiguration(new ContactTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContactsConfiguration());
            modelBuilder.ApplyConfiguration(new CountriesConfiguration());
            modelBuilder.ApplyConfiguration(new CustomersConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeesConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ApplyConfiguration(new ShippersConfiguration());
            modelBuilder.ApplyConfiguration(new SuppliersConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        #region Takes care of disposing stream used for logging
        public override void Dispose()
        {
            base.Dispose();
            _logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await _logStream.DisposeAsync();
        }
        #endregion
    }
}
