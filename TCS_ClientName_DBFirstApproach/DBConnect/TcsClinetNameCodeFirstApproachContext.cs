using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TCS_ClientName_DBFirstApproach.DBConnect;

public partial class TcsClinetNameCodeFirstApproachContext : DbContext
{
    public TcsClinetNameCodeFirstApproachContext()
    {
    }

    public TcsClinetNameCodeFirstApproachContext(DbContextOptions<TcsClinetNameCodeFirstApproachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departement> Departements { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-AAO14OC;Database=TCS_ClinetNameCodeFirstApproach;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departement>(entity =>
        {
            entity.HasKey(e => e.Deptid);

            entity.ToTable("departements");

            entity.Property(e => e.Deptid).HasColumnName("deptid");
            entity.Property(e => e.Deptlocation).HasColumnName("deptlocation");
            entity.Property(e => e.Deptname).HasColumnName("deptname");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Empid);

            entity.ToTable("employees");

            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Empname).HasColumnName("empname");
            entity.Property(e => e.Empsalary).HasColumnName("empsalary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
