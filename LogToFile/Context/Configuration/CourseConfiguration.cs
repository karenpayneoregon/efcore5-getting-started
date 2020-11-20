﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using LogToFile.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;

namespace LogToFile.Context
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> entity)
        {
            entity.ToTable("Course");

            entity.Property(e => e.CourseID).ValueGeneratedNever();

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.Department)
                .WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Course_Department");
        }
    }
}