using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using StoredProcedureEntityFrameworkCore1.Models;


namespace StoredProcedureEntityFrameworkCore1.Context
{
    public class ShippersConfiguration : IEntityTypeConfiguration<Shippers>
    {
        public void Configure(EntityTypeBuilder<Shippers> entity)
        {
            entity.HasKey(e => e.ShipperId);

            entity.Property(e => e.ShipperId)
                .HasColumnName("ShipperID")
                .ValueGeneratedNever();

            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.Phone).HasMaxLength(24);
        }
    }
}
