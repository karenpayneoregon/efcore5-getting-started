﻿using System.IO;
using ConfigurationHelper;
using IncludeFilter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace IncludeFilter.Context
{
    public partial class DatabasefirstBloggingContext : DbContext
    {
        public DatabasefirstBloggingContext()
        {
        }

        public DatabasefirstBloggingContext(DbContextOptions<DatabasefirstBloggingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Helper.ConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.BlogId).HasMaxLength(200).HasComment("Blog identifier");
                entity.Property(e => e.Name).HasMaxLength(200).HasComment("Blog name");
                entity.Property(e => e.Title).HasMaxLength(200).HasComment("Blog Title");

                entity.Property(e => e.Url).HasMaxLength(200).HasComment("Web address");
                entity.Property(e => e.DateModified).HasComment("Modified");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.Content)
                    .HasColumnType("ntext")
                    .HasAnnotation("Relational:ColumnType", "ntext");

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("FK_dbo.Posts_dbo.Blogs_BlogId");
            });


            //OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}