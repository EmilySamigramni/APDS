using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TheAgriApp.Models;

public partial class TheAgriContext : DbContext
{
    public TheAgriContext()
    {
    }

    public TheAgriContext(DbContextOptions<TheAgriContext> options)
    : base(options)
    {
    }

    public virtual DbSet<Farmer> Farmers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
           => optionsBuilder.UseSqlServer("Server=labVMH8OX\\SQLEXPRESS;Database=TheAgri;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Farmer>(entity =>
        {
            entity.HasKey(e => e.FarmerId).HasName("PK__Farmers__731B88E88E84A4EC");

            entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6EDE2883DF5");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(100);

            entity.HasOne(d => d.Farmer).WithMany(p => p.Products)
            .HasForeignKey(d => d.FarmerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Products_Farmers");
        });

      

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}