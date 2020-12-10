using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using StoredProcedureEntityFrameworkCore1.Models;

namespace StoredProcedureEntityFrameworkCore1.Context
{
    public class CountriesConfiguration : IEntityTypeConfiguration<Countries>
    {
        public void Configure(EntityTypeBuilder<Countries> entity)
        {
            entity.HasKey(e => e.CountryIdentifier);
        }
    }
}
