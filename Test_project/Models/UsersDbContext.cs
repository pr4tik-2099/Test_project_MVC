using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Test_project.Models;

public partial class UsersDbContext : DbContext
{
    public UsersDbContext()
    {
    }

    public UsersDbContext(DbContextOptions<UsersDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:dbcs");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EId).HasName("PK__employee__D7E94DACE0819541");

            entity.ToTable("employees");

            entity.Property(e => e.EId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("E_id");
            entity.Property(e => e.EName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("E_name");
            entity.Property(e => e.ESalary).HasColumnName("E_salary");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.SId).HasName("PK__salary__2F3DA3DCD41DE1A4");

            entity.Property(e => e.SId).HasColumnName("s_Id");
            entity.Property(e => e.EmpId).HasColumnName("emp_Id");
            entity.Property(e => e.EmpRole)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("emp_Role");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.SId).HasName("PK__States__2F3684F47889C719");

            entity.Property(e => e.SId).HasColumnName("s_id");
            entity.Property(e => e.SName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("s_Name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F1F4B7BE8");

            entity.ToTable("users");

            entity.HasIndex(e => e.MobileNo, "UQ__users__60678903AD1322C5").IsUnique();

            entity.HasIndex(e => e.EmailId, "UQ__users__B79555BE1C905007").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Email_Id");
            entity.Property(e => e.Gender)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Hobbies)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Mobile_No");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
