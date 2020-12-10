using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using StoredProcedureEntityFrameworkCore1.Models;


namespace StoredProcedureEntityFrameworkCore1.Context
{
    public class PhoneTypeConfiguration : IEntityTypeConfiguration<PhoneType>
    {
        public void Configure(EntityTypeBuilder<PhoneType> entity)
        {
            entity.HasKey(e => e.PhoneTypeIdenitfier);
        }
    }
}
