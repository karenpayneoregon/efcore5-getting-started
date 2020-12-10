﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using StoredProcedureEntityFrameworkCore1.Models;

namespace StoredProcedureEntityFrameworkCore1.Context
{
    public class CustomersConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> entity)
        {
            entity.HasKey(e => e.CustomerIdentifier)
                .HasName("PK_Customers_1");

            entity.Property(e => e.CustomerIdentifier).HasComment("Id");

            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasComment("City");

            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("Company");

            entity.Property(e => e.ContactId).HasComment("ContactId");

            entity.Property(e => e.ContactTypeIdentifier).HasComment("ContactTypeIdentifier");

            entity.Property(e => e.CountryIdentifier).HasComment("CountryIdentifier");

            entity.Property(e => e.Fax)
                .HasMaxLength(24)
                .HasComment("Fax");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Modified Date");

            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasComment("Phone");

            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasComment("Postal Code");

            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasComment("Region");

            entity.Property(e => e.Street)
                .HasMaxLength(60)
                .HasComment("Street");

            entity.HasOne(d => d.Contact)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK_Customers_Contacts");

            entity.HasOne(d => d.ContactTypeIdentifierNavigation)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.ContactTypeIdentifier)
                .HasConstraintName("FK_Customers_ContactType");

            entity.HasOne(d => d.CountryIdentifierNavigation)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.CountryIdentifier)
                .HasConstraintName("FK_Customers_Countries");
        }
    }
}
