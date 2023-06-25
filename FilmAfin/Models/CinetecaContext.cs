using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FilmAfin.Models;

public partial class CinetecaContext : DbContext
{
    public CinetecaContext()
    {
    }

    public CinetecaContext(DbContextOptions<CinetecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genero> Genero { get; set; }

    public virtual DbSet<GeneroBackup> GeneroBackup { get; set; }

    public virtual DbSet<Generos> Generos { get; set; }

    public virtual DbSet<Peliculas> Peliculas { get; set; }

    public virtual DbSet<PeliculasBackup> PeliculasBackup { get; set; }

    public virtual DbSet<Productores> Productores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("user=root;password=adlogcat45;server=localhost;database=Cineteca", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("genero");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<GeneroBackup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("genero_backup");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Generos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("generos");

            entity.HasIndex(e => e.IdGenero, "Fk_GenerosGenero");

            entity.HasIndex(e => e.IdPelicula, "Fk_GenerosPelicualas");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Generos)
                .HasForeignKey(d => d.IdGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_GenerosGenero");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.Generos)
                .HasForeignKey(d => d.IdPelicula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_GenerosPelicualas");
        });

        modelBuilder.Entity<Peliculas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("peliculas");

            entity.Property(e => e.Año)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Pais).HasMaxLength(100);
            entity.Property(e => e.Titulo).HasMaxLength(100);
            entity.Property(e => e.TituloOriginal).HasMaxLength(100);
        });

        modelBuilder.Entity<PeliculasBackup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("peliculas_backup");

            entity.Property(e => e.Año)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Pais).HasMaxLength(100);
            entity.Property(e => e.Titulo).HasMaxLength(100);
            entity.Property(e => e.TituloOriginal).HasMaxLength(100);
        });

        modelBuilder.Entity<Productores>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productores");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
