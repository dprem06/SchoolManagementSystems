using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace DataAccessLayer.Models
{
    public partial class StudentManagementContext : DbContext
    {
        public StudentManagementContext()
        {
        }

        public StudentManagementContext(DbContextOptions<StudentManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(e => e.CourseDescription)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
