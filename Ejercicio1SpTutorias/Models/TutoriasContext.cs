using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio1SpTutorias.Models;

public partial class TutoriasContext : DbContext
{
    public TutoriasContext()
    {
    }

    public TutoriasContext(DbContextOptions<TutoriasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumnos> Alumnos { get; set; }

    public virtual DbSet<Asesorias> Asesorias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; user=gollo;integrated security=true;Database=Tutorias");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumnos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alumnos__3214EC0712F95D25");

            entity.Property(e => e.Evaluacion)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.NumeroControl)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Asesorias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Asesoria__3214EC07E389135C");

            entity.Property(e => e.Asesor)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Hora)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTutoradoNavigation).WithMany(p => p.Asesorias)
                .HasForeignKey(d => d.IdTutorado)
                .HasConstraintName("fkAsesoriasAlumn");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
