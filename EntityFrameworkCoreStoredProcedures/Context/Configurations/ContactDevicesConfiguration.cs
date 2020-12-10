﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using StoredProcedureEntityFrameworkCore1.Models;

namespace StoredProcedureEntityFrameworkCore1.Context
{
    public class ContactDevicesConfiguration : IEntityTypeConfiguration<ContactDevices>
    {
        public void Configure(EntityTypeBuilder<ContactDevices> entity)
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Contact)
                .WithMany(p => p.ContactDevices)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK_ContactDevices_Contacts1");

            entity.HasOne(d => d.PhoneTypeIdentifierNavigation)
                .WithMany(p => p.ContactDevices)
                .HasForeignKey(d => d.PhoneTypeIdentifier)
                .HasConstraintName("FK_ContactDevices_PhoneType");
        }
    }
}
