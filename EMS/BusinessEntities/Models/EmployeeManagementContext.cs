using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BusinessEntities.Models
{
    public partial class EmployeeManagementContext : DbContext
    {
        public EmployeeManagementContext()
        {
        }

        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DSK-023\\SQL2017;Database=EmployeeManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

               

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Manager)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Phone).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Password).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
