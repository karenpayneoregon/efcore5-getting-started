using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using StoredProcedureEntityFrameworkCore1.Models;


namespace StoredProcedureEntityFrameworkCore1.Context
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> entity)
        {
            entity.HasKey(e => e.ProductId);

            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            entity.Property(e => e.UnitPrice).HasColumnType("money");

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Supplier)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Products_Suppliers");
        }
    }
}
