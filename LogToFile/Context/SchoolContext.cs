
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using ConfigurationHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LogToFile.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

#nullable disable

namespace LogToFile.Context
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseDay> CourseDays { get; set; }
        public virtual DbSet<CourseInstructor> CourseInstructors { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public virtual DbSet<OnlineCourse> OnlineCourses { get; set; }
        public virtual DbSet<OnsiteCourse> OnsiteCourses { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<StudentGrade> StudentGrades { get; set; }
        public virtual DbSet<WeekDayName> WeekDayNames { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                switch (Helper.LoggingDistination())
                {
                    case LoggingDistination.DebugWindow:
                        LogQueryInfoToDebugOutputWindow(optionsBuilder);
                        break;
                    case LoggingDistination.LogFile:
                        LogQueryInfoToFile(optionsBuilder);
                        break;
                    case LoggingDistination.None:
                        NoLogging(optionsBuilder);
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CourseDayConfiguration());
            modelBuilder.ApplyConfiguration(new CourseInstructorConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeAssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new OnlineCourseConfiguration());
            modelBuilder.ApplyConfiguration(new OnsiteCourseConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new StudentGradeConfiguration());
            modelBuilder.ApplyConfiguration(new WeekDayNameConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
