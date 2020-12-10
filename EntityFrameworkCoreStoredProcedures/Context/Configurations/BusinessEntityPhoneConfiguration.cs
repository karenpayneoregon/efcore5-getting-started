using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using StoredProcedureEntityFrameworkCore1.Models;


namespace StoredProcedureEntityFrameworkCore1.Context
{
    public class BusinessEntityPhoneConfiguration : IEntityTypeConfiguration<BusinessEntityPhone>
    {
        public void Configure(EntityTypeBuilder<BusinessEntityPhone> entity)
        {
            entity.Property(e => e.BusinessEntityPhoneId).HasColumnName("BusinessEntityPhoneID");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.PhoneNumber).HasComment("Phone number");

            entity.Property(e => e.PhoneNumberTypeId).HasColumnName("PhoneNumberTypeID");
        }
    }
}
