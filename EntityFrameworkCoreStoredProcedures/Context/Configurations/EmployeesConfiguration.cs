﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using StoredProcedureEntityFrameworkCore1.Models;

namespace StoredProcedureEntityFrameworkCore1.Context
{
    public class EmployeesConfiguration : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> entity)
        {
            entity.HasKey(e => e.EmployeeId);

            entity.Property(e => e.EmployeeId)
                .HasColumnName("EmployeeID")
                .HasComment("Id")
                .ValueGeneratedNever();

            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasComment("Street");

            entity.Property(e => e.BirthDate)
                .HasColumnType("datetime")
                .HasComment("Birth date");

            entity.Property(e => e.City).HasMaxLength(15);

            entity.Property(e => e.Extension).HasMaxLength(4);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(10)
                .HasComment("First name");

            entity.Property(e => e.HireDate)
                .HasColumnType("datetime")
                .HasComment("Hiredate");

            entity.Property(e => e.HomePhone)
                .HasMaxLength(24)
                .HasComment("Home phone");

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("Last name");

            entity.Property(e => e.PostalCode).HasMaxLength(10);

            entity.Property(e => e.Region).HasMaxLength(15);

            entity.Property(e => e.ReportsTo).HasComment("Manager");

            entity.Property(e => e.TitleOfCourtesy)
                .HasMaxLength(25)
                .HasComment("Title");

            entity.HasOne(d => d.ContactTypeIdentifierNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.ContactTypeIdentifier)
                .HasConstraintName("FK_Employees_ContactType");

            entity.HasOne(d => d.CountryIdentifierNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.CountryIdentifier)
                .HasConstraintName("FK_Employees_Countries");
        }
    }
}
