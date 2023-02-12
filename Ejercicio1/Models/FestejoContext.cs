using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio1.Models;

public partial class FestejoContext : DbContext
{
    public FestejoContext()
    {
    }

    public FestejoContext(DbContextOptions<FestejoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Menor> Menor { get; set; }

    public virtual DbSet<Vwcumplehoy> Vwcumplehoy { get; set; }

    public virtual DbSet<Vwcumplemes> Vwcumplemes { get; set; }

    public virtual DbSet<Vwmayoredad> Vwmayoredad { get; set; }

    public virtual DbSet<Vwmenoresedad> Vwmenoresedad { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=adlogcat45;database=Festejo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Menor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("menor");

            entity.Property(e => e.Domicilio).HasColumnType("text");
            entity.Property(e => e.FechaNacimiento)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Vwcumplehoy>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwcumplehoy");

            entity.Property(e => e.Domicilio).HasColumnType("text");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Vwcumplemes>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwcumplemes");

            entity.Property(e => e.Domicilio).HasColumnType("text");
            entity.Property(e => e.FechaNacimiento)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Vwmayoredad>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwmayoredad");

            entity.Property(e => e.Domicilio).HasColumnType("text");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Vwmenoresedad>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwmenoresedad");

            entity.Property(e => e.Domicilio).HasColumnType("text");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
