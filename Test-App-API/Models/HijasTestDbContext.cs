using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Test_App_API.Models;

public partial class HijasTestDbContext : DbContext
{
    public HijasTestDbContext()
    {
    }

    public HijasTestDbContext(DbContextOptions<HijasTestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Designation> Designations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Designation>(entity =>
        {
            entity.ToTable("Designation");

            entity.Property(e => e.Designation1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Designation");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
