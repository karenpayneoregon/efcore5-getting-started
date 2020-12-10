using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using StoredProcedureEntityFrameworkCore1.Models;

namespace StoredProcedureEntityFrameworkCore1.Context
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> entity)
        {
            entity.HasKey(e => e.CategoryId);

            entity.Property(e => e.CategoryId)
                .HasColumnName("CategoryID")
                .HasComment("Primary key");

            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            entity.Property(e => e.Description).HasColumnType("ntext");

            entity.Property(e => e.Picture).HasColumnType("image");
        }
    }
}
