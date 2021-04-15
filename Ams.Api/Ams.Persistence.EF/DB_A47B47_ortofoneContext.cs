using System;
using Ams.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ams.Persistence.EF
{
    public partial class DB_A47B47_ortofoneContext : DbContext
    {
        public DB_A47B47_ortofoneContext()
        {
        }

        public DB_A47B47_ortofoneContext(DbContextOptions<DB_A47B47_ortofoneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentsManagerNumber> DepartmentsManagerNumbers { get; set; }
        public virtual DbSet<DepartmentsView> DepartmentsViews { get; set; }
        public virtual DbSet<DeptEmp> DeptEmps { get; set; }
        public virtual DbSet<DeptManager> DeptManagers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeesView> EmployeesViews { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<Title> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptNo)
                    .HasName("PK__departme__DCA63FA6D3E1DD87");

                entity.ToTable("departments");

                entity.HasIndex(e => e.DeptName, "UQ__departme__C7D39AE1F10B3857")
                    .IsUnique();

                entity.Property(e => e.DeptNo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("dept_no")
                    .IsFixedLength(true);

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("dept_name");
            });

            modelBuilder.Entity<DepartmentsManagerNumber>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DepartmentsManagerNumber");

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("dept_name");

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("last_name");
            });

            modelBuilder.Entity<DepartmentsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DepartmentsView");

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("dept_name");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("last_name");
            });

            modelBuilder.Entity<DeptEmp>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.DeptNo });

                entity.ToTable("dept_emp");

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.DeptNo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("dept_no")
                    .IsFixedLength(true);

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("from_date");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("to_date");

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.DeptEmps)
                    .HasForeignKey(d => d.DeptNo)
                    .HasConstraintName("FK__dept_emp__dept_n__403A8C7D");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.DeptEmps)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("FK__dept_emp__emp_no__3F466844");
            });

            modelBuilder.Entity<DeptManager>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.DeptNo });

                entity.ToTable("dept_manager");

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.DeptNo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("dept_no")
                    .IsFixedLength(true);

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("from_date");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("to_date");

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.DeptManagers)
                    .HasForeignKey(d => d.DeptNo)
                    .HasConstraintName("FK__dept_mana__dept___3C69FB99");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.DeptManagers)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("FK__dept_mana__emp_n__3B75D760");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpNo);

                entity.ToTable("employees");

                entity.Property(e => e.EmpNo)
                    .ValueGeneratedNever()
                    .HasColumnName("emp_no");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender")
                    .IsFixedLength(true);

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hire_date");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("last_name");
            });

            modelBuilder.Entity<EmployeesView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EmployeesView");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender")
                    .IsFixedLength(true);

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hire_date");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.FromDate });

                entity.ToTable("salaries");

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("from_date");

                entity.Property(e => e.Salary1).HasColumnName("salary");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("to_date");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("FK__salaries__emp_no__45F365D3");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.Title1, e.FromDate });

                entity.ToTable("titles");

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.Title1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.FromDate)
                    .HasColumnType("date")
                    .HasColumnName("from_date");

                entity.Property(e => e.ToDate)
                    .HasColumnType("date")
                    .HasColumnName("to_date");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.Titles)
                    .HasForeignKey(d => d.EmpNo)
                    .HasConstraintName("FK__titles__emp_no__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
